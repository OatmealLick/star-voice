using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour {
	List<int> plotDecisions = new List<int>();
	//int plot = 0;
    private ForestPlot forestPlot;
	// Use this for initialization
	void Start () {
        forestPlot = GetComponent<ForestPlot>();
        CallPlotStep(1);
	}
	
    public void CallPlotStep(int stepNumber){
        switch (stepNumber)
        {
            case 1:
                forestPlot.ADarkForest();
                break;
            case 2:
                forestPlot.WhereAmI();
                break;
            default:

                break;
        }
    }


	// Update is called once per frame
	void Update () {
		
	}
}
