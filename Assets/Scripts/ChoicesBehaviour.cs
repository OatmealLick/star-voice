﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoicesBehaviour : MonoBehaviour {
	
	private GameObject[] choices;
	private float widthScale = 0.8f;
	private int choiceHeightInPixels = 100;
    public int nextPlotSteps;
	public string[] choiceTexts;
    public GameObject plot;
	// Use this for initialization
	void Start () {
        // load choice GameObject to enable instantiating
        plot = GameObject.Find("PlotHandler");
		GameObject choice = (GameObject)Resources.Load ("Choice");
		Rect rect = gameObject.GetComponent<RectTransform> ().rect;
		rect.width = widthScale * gameObject.transform.parent.GetComponent<RectTransform> ().rect.width;
		rect.height = choiceTexts.Length * choiceHeightInPixels;

		// initialise choices array
		choices = new GameObject[choiceTexts.Length];

		Vector3 pos = gameObject.transform.position;

		// for every choice option instantiate GO, set transform and proper text
		for (int i = 0; i < choices.Length; i++) {
			choices [i] = Instantiate (choice, pos + new Vector3(0, -i*choiceHeightInPixels, 0), transform.rotation);
			choices [i].transform.SetParent (gameObject.transform, false);
            int g = i;
            Debug.Log(nextPlotSteps + g);
            choices [i].GetComponent<Button>().onClick.AddListener(() => AdvanceInPlot(nextPlotSteps + g));
			// TODO set transform and rotation
			choices [i].GetComponentInChildren<Text>().text=choiceTexts[i];
		}
	}
    public void AdvanceInPlot(int nextStep)
    {
        plot.GetComponent<Plot>().NextStep(1, nextStep);
        Destroy(this.gameObject);
    }
}
