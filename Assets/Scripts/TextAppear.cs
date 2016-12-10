using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextAppear : MonoBehaviour {

	private Text text;
	public string stringToDisplay = "Where am I?";
	public float timeToDisplay = -1;
	public float timeToStay = 2f;

	private float readerSpeed = 13;
	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent<Text> ();
		StartCoroutine (AnimateText(stringToDisplay));


		if (timeToDisplay == -1)
			timeToDisplay = stringToDisplay.Length / readerSpeed;
	}

	IEnumerator AnimateText (string finalString) {
		float waitSec = timeToDisplay / stringToDisplay.Length;
		int i = 0;
		string str = string.Empty;
		while(i < stringToDisplay.Length){
			str += stringToDisplay[i++];
			text.text = str;
			yield return new WaitForSeconds(waitSec);

		}
		yield return new WaitForSeconds (timeToStay);
		text.text = string.Empty;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
