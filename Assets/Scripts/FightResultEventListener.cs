using UnityEngine;
using System.Collections;

public class FightResultEventListener : MonoBehaviour
{
	public int health = 3;
	public float timeForAttack = 3f;
	public int attackCount = 3;
	public float delay = 0f;

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
			InstantiateFight (timeForAttack);
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

	void InstantiateFight(float exactTime) {
		GameObject fight = Instantiate (fightPrefab);
		if (Mathf.Abs(exactTime - 3f) < 0.001f) {
			fight.GetComponent<FightInstance> ().time = exactTime;
		}
	}
}

