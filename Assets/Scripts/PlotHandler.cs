using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlotHandler : MonoBehaviour
{
	public List<PlotPiece> plotList = new List<PlotPiece> ();
	public IEnumerator it;

	// Background image Canvas
	private Transform backgroundCanvasTr;
	private GameObject currBackground;

	// UI, Text Canvas
	private Transform renderCanvasTr;

	// GO Resources containing TextAppear script
	private GameObject defaultText;

	// for now this is how it looks like
	public ChoicesBehaviour.ChoiceCallbacks[] choiceCallbacks;

	// prefab to instantiate choices from
	public GameObject choices;

	private TextAppear currentTextAppear;

	private bool isDisplaying = false;

	public void DisplayText(string text, TextAppear.TextSpeed speakerSpeed, TextPosition pos) {
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
		it = plotList.GetEnumerator ();
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

		if (!isDisplaying && it.MoveNext()) {
			isDisplaying = true;
			PlotPiece pp = (PlotPiece)it.Current;

			if (pp.isChoice ()) {
				// TODO real work
				GameObject instantiatedChoice = Instantiate(choices);
				instantiatedChoice.transform.SetParent (renderCanvasTr, false);
				ChoicesBehaviour cb = instantiatedChoice.GetComponent<ChoicesBehaviour>();
				cb.choiceTexts = pp.texts;
				cb.SetChoiceCallbacks (choiceCallbacks);
				//bridgeOrLabs.choiceTexts = choiceLibrary.GetChoice(4);
				//bridgeOrLabs.nextPlotSteps = 1;



				//instantiatedChoice.transform.SetParent(renderCanvas.transform, false);
			} else {
				DisplayText (pp.texts[0], pp.speakerSpeed, pp.textPosition);

				float timeOffset;

				switch (pp.speakerSpeed) {
				case TextAppear.TextSpeed.HIGH:
					timeOffset = ((TextAppear.SINGLE_CHAR_OFFSET_HIGH + 0.0145f) * pp.texts [0].Length)
						+ TextAppear.TIME_TO_STAY_HIGH;
					break;
				case TextAppear.TextSpeed.NORMAL:
					timeOffset = ((TextAppear.SINGLE_CHAR_OFFSET_NORMAL + 0.0145f) * pp.texts [0].Length)
						+ TextAppear.TIME_TO_STAY_NORMAL;
					break;
				default:
					timeOffset = ((TextAppear.SINGLE_CHAR_OFFSET_LOW + 0.0145f) * pp.texts [0].Length)
						+ TextAppear.TIME_TO_STAY_LOW;
					break;
				}

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
					
				Invoke ("DoneDisplaying", timeOffset);
			}
		}
	}

	private void DoneDisplaying() {
		isDisplaying = false;
	}

	public void Add(PlotPiece piece) {
		plotList.Add (piece);
	}

	public void Add(PlotPiece piece, ChoicesBehaviour.ChoiceCallbacks[] choiceCallbacks) {
		Add (piece);
		this.choiceCallbacks = choiceCallbacks;
	}

	private void DestroyText() {
		isDisplaying = false;
		Destroy(currentTextAppear.transform.parent.gameObject);
	}
}

