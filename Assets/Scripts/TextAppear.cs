using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextAppear : MonoBehaviour {

	// if you want to make changes to display speed here is the place
	// the lower value you set, the quicker the text flies
	// SINGLE_CHAR_OFFSET
	// bear in mind that these are'nt exactly 1:1 speed of character interval
	// unity performs other actions which adds up to this amount (~0.14f)
	//
	// TIME_TO_STAY
	// amount of time the text persists after being wholly displayed
	// matched 1:1 in seconds
	public const float SINGLE_CHAR_OFFSET_HIGH = 0.04f;
	public const float SINGLE_CHAR_OFFSET_NORMAL = 0.07f;
	public const float SINGLE_CHAR_OFFSET_LOW = 0.1f;
	public const float TIME_TO_STAY_HIGH = 1.3f;
	public const float TIME_TO_STAY_NORMAL = 2.5f;
	public const float TIME_TO_STAY_LOW = 2.6f;

	// THIS IS GLOBAL SETTING GAMER SETS UP IN OPTIONS
	// IT IS TO BE CHANGED ONLY VIA OPTIONS AND HAVE IMPACT ON EVERY SIGNLE
	// TEXT DISPLAYED IN GAME
	public static TextSpeed readerSpeed = TextSpeed.NORMAL;

	// This is local setting, it may vary for each object
	// Keep in mind this is the value of SPEAKER's speed
	// You should adjust this value to match voice acting
	public TextSpeed speakerSpeed = TextSpeed.NORMAL;
	public Text textToDisplay;
	public string stringToDisplay;
	public float waitForSingleChar;
	public float timeToStay;
	public float textDisplaySpeed;

	public Coroutine co;
	// Use this for initialization
	void Start () {

		// sets SPEAKER's tempo
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

		// here comes global setting scaling
		// TODO twitch these to properly match everything
		switch(readerSpeed) {
		case TextSpeed.HIGH:
			waitForSingleChar *= 0.73f;
			timeToStay = TIME_TO_STAY_HIGH - 0.4f;
			break;
		case TextSpeed.LOW:
			waitForSingleChar *= 1.2f;
			timeToStay = TIME_TO_STAY_LOW + 0.4f;
			break;

		}
			
		textToDisplay = gameObject.GetComponent<Text> ();
        co = StartCoroutine (AnimateText(stringToDisplay));
	}

    public void SetText(string text){
        stringToDisplay = text;
    }

	IEnumerator AnimateText (string finalString) {
		int i = 0;
		string str = string.Empty;
		while(i < stringToDisplay.Length){
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
