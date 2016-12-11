using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FightResultEventListenerRunning : MonoBehaviour
{
	public int health = 3;
	public float timeForAttack = 3f;
	public int attackCount = 3;
	public float delay = 0f;
    public int hitsToKill = 3;
	public float delaySingleFightInstance = 3.5837237f;
	private Plot plot;
	private bool fightInProgress = false;
	public bool startFight = false;
	private int fightNumber = 0;
	private Coroutine co;

	private GameObject fightPrefab;

	// Use this for initialization
	void Start () {
		plot = GameObject.Find ("PlotHandler").GetComponent<Plot> ();
		FightInstance.FightWon += IncreaseHealth;
		FightInstance.FightLost += DecreaseHealth;
		fightPrefab = (GameObject)Resources.Load ("Fight");
		Invoke ("EnableFighting", delay);
	}

	// Update is called once per frame
	void Update () {
		if(startFight==true && fightInProgress==true && (health > attackCount - fightNumber || fightNumber == attackCount)){
			fightInProgress = false;
			startFight = false;
			fightNumber = attackCount;
			WonTheWholeBattle();
		}
		if (startFight==true && !fightInProgress && fightNumber<attackCount) {
			fightInProgress = true;
			co = StartCoroutine(DelayInstantiateFight(timeForAttack, delaySingleFightInstance));
			//InstantiateFight (timeForAttack);
			fightNumber++;
		}
	}

	void EnableFighting() {
		startFight = true;
	}

	void DecreaseHealth() {
		Debug.Log ("lost");
		fightInProgress = false;
		health--;
        if (health <= 0)
        {
            fightInProgress = false;
            LostTheWholeBattle();
        }
	}

	void IncreaseHealth() {
		Debug.Log ("won");
		fightInProgress = false;
                                         //health++;
                                         // actually why would you get hp for won battle?
    }

	void OnDestroy() {
		FightInstance.FightWon -= IncreaseHealth;
		FightInstance.FightLost -= DecreaseHealth;
	}

	IEnumerator DelayInstantiateFight(float exactTime, float delayFight) {
		yield return new WaitForSeconds (delayFight);
		InstantiateFight (exactTime);

	}

	void InstantiateFight(float exactTime) {
		GameObject fight = Instantiate (fightPrefab);
		//if (Mathf.Abs(exactTime - 3f) < 0.001f) {
			fight.GetComponent<FightInstance> ().time = exactTime;
		//}
	}
    void WonTheWholeBattle()
    {
		//Destroy (GameObject.Find ("Bear(Clone)"));
		//Destroy (GameObject.Find ("Wood(Clone)"));
		startFight = false;
		StopCoroutine (co);
        Debug.Log("won everything");
		Invoke ("RanAway", 4.5f);
    }
    void LostTheWholeBattle()
    {
        Debug.Log("lost everything");

		//Destroy (GameObject.Find ("Bear(Clone)"));
		//Destroy (GameObject.Find ("Wood(Clone)"));
		//Destroy (GameObject.Find ("FightEventsListener(Clone)"));
		startFight = false;
		Invoke ("Respawn", 7f);

    }

	void Respawn() {
		// TODO check this
		plot.NextStep (1, 6);

		Destroy (gameObject);
	}

	void RunAway() {
		Debug.Log ("You ran away! - Load Scene here");
		//SceneManager.LoadScene ("SpaceShip");
		Destroy (gameObject);
	}
}

