using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour {
	//int plot = 0;
	public int currentStep = 0;
	private ForestPlot forestPlot;
	// Use this for initialization
	void Start () {
		
	}
	virtual public void BeginPlot(){
		
	}
	virtual public void NextStep(int jump=1, int current=-1){
		
	}
	virtual public void CallPlotStep(int stepNumber){
		
	}


	// Update is called once per frame
	void Update () {

	}
}
