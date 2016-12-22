using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoicesBehaviour : MonoBehaviour {
	
	private GameObject[] choices;
	public delegate void ChoiceCallbacks();
	public ChoiceCallbacks[] choiceCallbacks;
	private float widthScale = 0.8f;
	private int choiceHeightInPixels = 100;
    public int nextPlotSteps;
	public string[] choiceTexts;
    //public GameObject plot;
	// Use this for initialization
	void Start () {
        // load choice GameObject to enable instantiating
        //plot = GameObject.Find("PlotHandler");
		GameObject choice = (GameObject)Resources.Load ("Choice");
		Rect rect = gameObject.GetComponent<RectTransform> ().rect;
		rect.width = widthScale * gameObject.transform.parent.GetComponent<RectTransform> ().rect.width;
		rect.height = choiceTexts.Length * choiceHeightInPixels;

		// initialise choices array
		choices = new GameObject[choiceTexts.Length];

		Vector3 pos = gameObject.transform.position;
		for (int i = 0; i < choices.Length; i++) {

			// instantiate choices and set theirs parameters
			choices [i] = Instantiate (choice, pos + new Vector3(0, -i*choiceHeightInPixels, 0), transform.rotation);
			choices [i].transform.SetParent (gameObject.transform, false);
			choices [i].GetComponentInChildren<Text>().text=choiceTexts[i];

			// little hack - to get Listener to work as intended (call method with parameter's value
			// which was set DURING this for-loop, not value exisitng WHILE method is CALLED
			int g = i;
			choices [i].GetComponent<Button>().onClick.AddListener(() => {
				choiceCallbacks [g] ();
				GameObject.Find("PlotMachine").GetComponent<PlotHandler> ().isDisplaying = false;
				Destroy(gameObject);
			});
		}
	}

	public void SetChoiceCallbacks(ChoiceCallbacks[] choiceCallbacks) {
		this.choiceCallbacks = choiceCallbacks;
	}
}
