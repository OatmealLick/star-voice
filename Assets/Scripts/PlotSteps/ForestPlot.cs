using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestPlot : MonoBehaviour {

    Canvas renderCanvas;
    private float plotTimer = 0.0f;
    private int currentStep = 1;
	private Plot plot;

	private GameObject defaultText;
   
	void Awake() {
		renderCanvas = (Canvas)GameObject.Find("Canvas").GetComponent<Canvas>();
		defaultText = (GameObject)Resources.Load ("DefaultText");
	}

	void Start() {
		plot = GetComponent<Plot> ();
		//Debug.Log (defaultText);
	}

    public void ADarkForest(){
        plotTimer = 10f; // how long text will be on screen

		GameObject textParent = Instantiate (defaultText);
        TextAppear displayText = textParent.GetComponentInChildren<TextAppear>();
        textParent.transform.SetParent(renderCanvas.transform, false);
        displayText.SetText("A dark forest. You are surrounded by trees rustling on a gentle breeze. There's no one around you.");
		Invoke ("CallWhereAmI", plotTimer);
	}

    public void WhereAmI() {
        plotTimer = 5f;
		GameObject textParent = Instantiate (defaultText);
        TextAppear displayText = textParent.GetComponentInChildren<TextAppear>();
        textParent.transform.SetParent(renderCanvas.transform, false);
        displayText.SetText("*Where am I?*");
    }


	private void CallWhereAmI() {
		plot.CallPlotStep (++currentStep);
	}

//    // Update is called once per frame
//    void Update () {
//        plotTimer -= Time.deltaTime;
//        if (plotTimer < 0){
//            GetComponent<Plot>().CallPlotStep(++currentStep); //calling next step (from Plot)
//        }
//	}
}

//TODO: usuwanie niepotrzebnych textów