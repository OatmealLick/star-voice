using UnityEngine;
using System.Collections;

public class FightResultEventListener : MonoBehaviour
{
	public int health = 3;
	public float timeForAttack = 3f;
	public int attackCount = 3;
	public float delay = 0f;
    public int hitsToKill = 3;
	public float delaySingleFightInstance = 3.5837237f;

	private bool fightInProgress = false;
	private bool startFight = false;
	private int fightNumber = 0;

	private GameObject fightPrefab;

	// Use this for initialization
	void Start () {
		FightInstance.FightWon += IncreaseHealth;
		FightInstance.FightLost += DecreaseHealth;
		fightPrefab = (GameObject)Resources.Load ("Fight");
		Invoke ("EnableFighting", delay);
	}
	
	// Update is called once per frame
	void Update () {
		if (startFight==true && !fightInProgress && fightNumber<attackCount) {
			fightInProgress = true;
			StartCoroutine(DelayInstantiateFight(timeForAttack, delaySingleFightInstance));
			//InstantiateFight (timeForAttack);
			fightNumber++;
		}

		if(fightInProgress==true && (health <= attackCount - fightNumber || fightNumber == attackCount)){
            fightInProgress = false;
            WonTheWholeBattle();
        }

	}

	void EnableFighting() {
		startFight = true;
	}

	void DecreaseHealth() {
		Debug.Log ("lost");
		fightInProgress = false;
		health--;
        WoodController.Pac(); // do zmiany Łukaszku
        if (health <= 0)
        {
            fightInProgress = false;
            LostTheWholeBattle();
        }
	}

	void IncreaseHealth() {
		Debug.Log ("won");
		fightInProgress = false;
        WoodController.AttackWithWood(); // do zmiany Łukaszku
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
		if (Mathf.Abs(exactTime - 3f) < 0.001f) {
			fight.GetComponent<FightInstance> ().time = exactTime;
		}
	}
    void WonTheWholeBattle()
    {
        Debug.Log("won everything");
    }
    void LostTheWholeBattle()
    {
        Debug.Log("lost everything");
    }
}

