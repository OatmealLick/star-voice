using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextAppear : MonoBehaviour {

	private Text textToDisplay;
	public string stringToDisplay = "Where am I?";
	public float timeToDisplay = -1;
	public float timeToStay = 2f;
	public float readerSpeed = 15;
	// Use this for initialization
	void Start () {
		textToDisplay = gameObject.GetComponent<Text> ();
        timeToDisplay = stringToDisplay.Length / readerSpeed;
        StartCoroutine (AnimateText(stringToDisplay));
	}

    public void SetText(string text){
        stringToDisplay = text;
    }

	IEnumerator AnimateText (string finalString) {
		float waitSec = timeToDisplay / stringToDisplay.Length;
		int i = 0;
		string str = string.Empty;
		while(i < stringToDisplay.Length){
			str += stringToDisplay[i++];
			textToDisplay.text = str;
			yield return new WaitForSeconds(waitSec);
		}
		yield return new WaitForSeconds (timeToStay);
		textToDisplay.text = string.Empty;
        Destroy(this.transform.parent.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
