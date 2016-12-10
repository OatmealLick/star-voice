﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour {
	//int plot = 0;
    public int currentStep = 0;
    private ForestPlot forestPlot;
	// Use this for initialization
	void Start () {
        forestPlot = GetComponent<ForestPlot>();
        Invoke("BeginPlot", 1f);
	}
    void BeginPlot(){
        CallPlotStep(++currentStep);
    }
	public void NextStep(int jump=1)
    {
        currentStep = currentStep + jump;
        CallPlotStep(currentStep);
    }
    public void CallPlotStep(int stepNumber){
        switch (stepNumber)
        {
            case 1:
                forestPlot.ADarkForest();
                break;
            case 2:
                forestPlot.Look();
                break;
            case 3:
                forestPlot.Walk();
                break;
            case 4:
                forestPlot.WhoMay();
                break;
            default:

                break;
        }
    }


	// Update is called once per frame
	void Update () {
		
	}
}
