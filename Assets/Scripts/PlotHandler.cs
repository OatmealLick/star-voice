using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlotHandler : MonoBehaviour
{
	public List<PlotPiece> plotList = new List<PlotPiece> ();
	public int iterator = 0;

	// Background image Canvas
	private Transform backgroundCanvasTr;
	private GameObject currBackground;

	// UI, Text Canvas
	private Transform renderCanvasTr;

	// GO Resources containing TextAppear script
	private GameObject defaultText;

	// for now this is how it looks like
	// used to pass methods specified in Act?Plot to call them when choice is clicked
	public ChoicesBehaviour.ChoiceCallbacks[] choiceCallbacks;

	// prefab to instantiate choices from
	public GameObject choices;


	// for background soundtrack
	// for every PlayOneShot event, e.g. someone speaks or screams
	public AudioSource musicSource;
	public AudioSource eventSource;
	private AudioClip eventClip;
	private AudioClip spareClip;
	private float eventClipVolume;
	private float spareClipVolume;

	private TextAppear currentTextAppear;

	public bool isDisplaying = false;

	public void DisplayText(string text, TextSpeed speakerSpeed, TextPosition pos) {
		GameObject textParent = Instantiate(defaultText);

		currentTextAppear = textParent.GetComponentInChildren<TextAppear>();
		currentTextAppear.speakerSpeed = speakerSpeed;
		textParent.transform.SetParent(renderCanvasTr, false);

		RectTransform rt = textParent.GetComponent<RectTransform> ();

		switch (pos) {
		case TextPosition.CENTER:
			rt.localPosition = new Vector3 (0, 0);
			break;
		case TextPosition.UP:
			rt.anchoredPosition = new Vector3 (0, (3.7f / 5f) * Screen.height);
			break;
		default: // BOTTOM
			rt.anchoredPosition = new Vector3 (0, -(3.7f / 5f) * Screen.height);
			break;
		}

		currentTextAppear.SetText (text);
	}

	void Start () {
		backgroundCanvasTr = GameObject.Find ("Canvas").transform;
		renderCanvasTr = GameObject.Find ("SecondCanvas").transform;
		defaultText = (GameObject)Resources.Load("DefaultText");
	}
	
	void Update () {
		if (isDisplaying && Input.GetKeyDown (KeyCode.Semicolon)) {
			StopCoroutine (currentTextAppear.co);
			currentTextAppear.textToDisplay.text = currentTextAppear.stringToDisplay;
			CancelInvoke ();
			Invoke ("DestroyText", currentTextAppear.timeToStay);
		}

		if (isDisplaying && Input.GetKeyDown (KeyCode.Quote)) {
			StopCoroutine (currentTextAppear.co);
			CancelInvoke ();
			Destroy(currentTextAppear.transform.parent.gameObject);
			isDisplaying = false;
		}

		if (!isDisplaying && plotList.Count > iterator) {
			isDisplaying = true;
			PlotPiece pp = (PlotPiece)plotList[iterator++];

			if (pp.isChoice ()) {
				
				// This is where each choice PlotPiece is handled
				GameObject instantiatedChoice = Instantiate (choices);
				instantiatedChoice.transform.SetParent (renderCanvasTr, false);
				ChoicesBehaviour cb = instantiatedChoice.GetComponent<ChoicesBehaviour> ();
				cb.choiceTexts = pp.texts;
				cb.SetChoiceCallbacks (choiceCallbacks);

				//instantiatedChoice.transform.SetParent(renderCanvas.transform, false);
			} else if (pp.isFight ()) {
				//GameObject fightSystem = new GameObject ();
				//FightManager fightManager = fightSystem.AddComponent<FightManager> ();
				pp.fightManager.SetActive(true);
//				fightManager.attackSpeedInSeconds = pp.fightManager.attackSpeedInSeconds;
//				fightManager.delay = pp.fightManager.delay;
//				fightManager.endPrefab = pp.fightManager.endPrefab;
//				fightManager.hitsToDie = pp.fightManager.hitsToDie;




			} else {

				// This is where each nonchoice PlotPiece is handled

				DisplayText (pp.texts[0], pp.speakerSpeed, pp.textPosition);

				float timeOffset;

				switch (pp.speakerSpeed) {
				case TextSpeed.HIGH:
					timeOffset = ((TextAppear.SINGLE_CHAR_OFFSET_HIGH + 0.0145f) * pp.texts [0].Length)
						+ TextAppear.TIME_TO_STAY_HIGH;
					break;
				case TextSpeed.NORMAL:
					timeOffset = ((TextAppear.SINGLE_CHAR_OFFSET_NORMAL + 0.0145f) * pp.texts [0].Length)
						+ TextAppear.TIME_TO_STAY_NORMAL;
					break;
				default:
					timeOffset = ((TextAppear.SINGLE_CHAR_OFFSET_LOW + 0.0145f) * pp.texts [0].Length)
						+ TextAppear.TIME_TO_STAY_LOW;
					break;
				}
					
				Invoke ("DoneDisplaying", timeOffset);
			}

			// both for choice and nonchoice Pieces

			// image handling
			if (!pp.keepOldBackground) {
				if (backgroundCanvasTr.childCount > 0) {
					// I suspect that if childCount is nonzero there is only ONE child
					Destroy (backgroundCanvasTr.GetChild (0).gameObject);
				}
			}

			if (pp.background != null) {
				GameObject newBackground = (GameObject) Instantiate(pp.background);
				newBackground.transform.SetParent(backgroundCanvasTr, false);
			}

			// audio handling
			if (!pp.keepOldBackgroundClip && musicSource.isPlaying && pp.backgroundClip != null) {
				StartCoroutine (AudioFadeOut.FadeOut (musicSource, 1f, pp.backgroundClip, pp.backgroundClipVolume));
//				musicSource.clip = pp.backgroundClip;
//				musicSource.volume = pp.backgroundClipVolume;
//				musicSource.Play ();
			} else if (!pp.keepOldBackgroundClip && musicSource.isPlaying) {
				StartCoroutine (AudioFadeOut.FadeOut (musicSource, 1f, null, 0f));
				//musicSource.Stop ();
			}

			if (pp.backgroundClip != null) {
				
			}

			if (pp.eventClip != null && Mathf.Abs (pp.eventClipDelay) < .0001f) {
				eventSource.PlayOneShot (pp.eventClip);
			} else if (pp.eventClip != null) {
				eventClip = pp.eventClip;
				eventClipVolume = pp.eventClipVolume;
				Invoke ("PlayOneShotDelayedEvent", pp.eventClipDelay);
			}

			if (pp.spareClip != null && Mathf.Abs (pp.spareClipDelay) < .0001f) {
				eventSource.PlayOneShot (pp.spareClip);
			} else if (pp.spareClip != null) {
				spareClip = pp.spareClip;
				spareClipVolume = pp.spareClipVolume;
				Invoke ("PlayOneShotDelayedSpare", pp.spareClipDelay);
			}

		}
	}

	// Change bool to false so Update can display another piece
	private void DoneDisplaying() {
		isDisplaying = false;
	}

	// Add piece to the queue
	public void Add(PlotPiece piece) {
		plotList.Add (piece);
	}

	// Add choice piece to the queue
	public void Add(PlotPiece piece, ChoicesBehaviour.ChoiceCallbacks[] choiceCallbacks) {
		Add (piece);
		this.choiceCallbacks = choiceCallbacks;
	}

	// Called when you're done with the text
	private void DestroyText() {
		isDisplaying = false;
		Destroy(currentTextAppear.transform.parent.gameObject);
	}

	private void PlayOneShotDelayedEvent() {
		musicSource.PlayOneShot (eventClip, eventClipVolume);
	}

	private void PlayOneShotDelayedSpare() {
		musicSource.PlayOneShot (spareClip, spareClipVolume);
	}
}

