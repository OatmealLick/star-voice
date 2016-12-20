using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextAppear : MonoBehaviour {

	public const float SINGLE_CHAR_OFFSET_HIGH = 0.056f;
	public const float SINGLE_CHAR_OFFSET_NORMAL = 0.08f;
	public const float SINGLE_CHAR_OFFSET_LOW = 0.1f;
	public const float TIME_TO_STAY_HIGH = 1.8f;
	public const float TIME_TO_STAY_NORMAL = 2.5f;
	public const float TIME_TO_STAY_LOW = 3f;

	public enum TextSpeed {
		LOW, NORMAL, HIGH
	};

	public static TextSpeed readerSpeed = TextSpeed.NORMAL;

	public TextSpeed speakerSpeed = TextSpeed.NORMAL;
	public Text textToDisplay;
	public string stringToDisplay;
	public float waitForSingleChar;
	public float timeToStay;
	public float textDisplaySpeed;

	public Coroutine co;
	// Use this for initialization
	void Start () {
		switch(speakerSpeed) {
		case TextSpeed.HIGH:
			waitForSingleChar = SINGLE_CHAR_OFFSET_HIGH;
			timeToStay = TIME_TO_STAY_HIGH;
			break;
		case TextSpeed.NORMAL:
			waitForSingleChar = SINGLE_CHAR_OFFSET_NORMAL;
			timeToStay = TIME_TO_STAY_NORMAL;
			break;
		case TextSpeed.LOW:
			waitForSingleChar = SINGLE_CHAR_OFFSET_LOW;
			timeToStay = TIME_TO_STAY_LOW;
			break;

		}
		textToDisplay = gameObject.GetComponent<Text> ();
        //timeToDisplay = stringToDisplay.Length / textDisplaySpeed;
        co = StartCoroutine (AnimateText(stringToDisplay));
	}

    public void SetText(string text){
        stringToDisplay = text;
    }

	IEnumerator AnimateText (string finalString) {
		//waitForSingleChar = timeToDisplay / stringToDisplay.Length;
		int i = 0;
		string str = string.Empty;
		while(i < stringToDisplay.Length){
			Debug.Log (Time.realtimeSinceStartup);
			str += stringToDisplay[i++];
			textToDisplay.text = str;
			yield return new WaitForSeconds(waitForSingleChar);
		}
		yield return new WaitForSeconds (timeToStay);
		textToDisplay.text = string.Empty;
        Destroy(this.transform.parent.gameObject);
	}


	
	// Update is called once per frame
	void Update () {
					
	}
}
