using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotAct2 : Plot
{
    //int plot = 0;
    //public int currentStep = 0;
    private SpacePlot spacePlot;
    // Use this for initialization
    void Start()
    {
        spacePlot = GetComponent<SpacePlot>();
        Invoke("BeginPlot", 1f);
    }
    override public void BeginPlot()
    {
        CallPlotStep(++currentStep);
    }
	public override void NextStep(int jump = 1, int current = -1)
    {
        Debug.Log(currentStep);
        if (current == -1) currentStep = currentStep + 1;
        else currentStep = current + jump;
        CallPlotStep(currentStep);
    }
    public override void CallPlotStep(int stepNumber)
    {
        switch (stepNumber)
        {
        case 1:
            spacePlot.Blood();
            break;
		case 2:
			spacePlot.Bridge ();
			break;
		case 3:
			spacePlot.Labs ();
			break;
            
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
