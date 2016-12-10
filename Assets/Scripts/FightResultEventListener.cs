using UnityEngine;
using System.Collections;

public class FightResultEventListener : MonoBehaviour
{
	public int health = 3;

	void onEnable() {
		
	}

	void onDisable() {
		
	}

	// Use this for initialization
	void Start ()
	{
		FightInstance.FightWon += IncreaseHealth;
		FightInstance.FightLost += DecreaseHealth;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown ("r")) {
			Instantiate ((GameObject)Resources.Load ("Fight"));
		}
	}

	void DecreaseHealth() {
		Debug.Log ("lost");
		health--;
	}

	void IncreaseHealth() {
		Debug.Log ("won");
		//health++;
		// actually why would you get hp for won battle?
	}

	void onDestroy() {
		FightInstance.FightWon -= IncreaseHealth;
		FightInstance.FightLost -= DecreaseHealth;
	}
}

