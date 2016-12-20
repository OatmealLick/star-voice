using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlotHandler : MonoBehaviour
{
	public List<PlotPiece> plotList = new List<PlotPiece> ();
	public IEnumerator it;

	private Transform renderCanvasTr;

	// GO Resources containing TextAppear script
	private GameObject defaultText;

	private TextAppear currentTextAppear;

	private bool isDisplaying = false;

	public void DisplayText(string text, TextAppear.TextSpeed speakerSpeed)
	{
		GameObject textParent = Instantiate(defaultText, new Vector3(0, 0), transform.rotation);
		currentTextAppear = textParent.GetComponentInChildren<TextAppear>();
		currentTextAppear.speakerSpeed = speakerSpeed;
		textParent.transform.SetParent(renderCanvasTr, false);
		currentTextAppear.SetText (text);
	}

	public void DisplayText(string text)
	{
		GameObject textParent = Instantiate(defaultText, new Vector3(0, 0), transform.rotation);
		currentTextAppear = textParent.GetComponentInChildren<TextAppear>();
		textParent.transform.SetParent(renderCanvasTr, false);
		currentTextAppear.SetText (text);
	}
//	public void DisplayUpperText(int lineNumber, int readerSpeed)
//	{
//		GameObject textParent = Instantiate(upperText);
//		TextAppear displayText = textParent.GetComponentInChildren<TextAppear>();
//		displayText.readerSpeed = readerSpeed;
//		textParent.transform.SetParent(renderCanvas.transform, false);
//		displayText.SetText(textLibrary.GetLine(lineNumber));
//		textParent.transform.SetAsFirstSibling();
//	}

	void Start () {
		renderCanvasTr = GameObject.Find ("SecondCanvas").transform;
		defaultText = (GameObject)Resources.Load("DefaultText");
		it = plotList.GetEnumerator ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isDisplaying && Input.GetKeyDown (KeyCode.BackQuote)) {
			StopCoroutine (currentTextAppear.co);
			currentTextAppear.textToDisplay.text = currentTextAppear.stringToDisplay;
			CancelInvoke ();
			Invoke ("DestroyText", currentTextAppear.timeToStay);
		}

		if (!isDisplaying && it.MoveNext()) {
			isDisplaying = true;
			PlotPiece pp = (PlotPiece)it.Current;

			if (pp.isChoice ()) {

			} else {
				DisplayText (pp.texts[0], pp.speakerSpeed);

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

	private void DestroyText() {
		isDisplaying = false;
		Destroy(currentTextAppear.transform.parent.gameObject);
	}
}

