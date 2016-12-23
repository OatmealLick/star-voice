using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEndLostBattleSelfDestruct : MonoBehaviour {

	private PlotHandler plotHandler;
	private float time = 3.2f;
	// Use this for initialization
	void Start () {
		plotHandler = GameObject.Find ("PlotMachine").GetComponent<PlotHandler> ();
		Invoke ("selfDestruct", time);
	}

	void selfDestruct() {
		plotHandler.isDisplaying = false;
		Destroy (gameObject);
	}
}
