using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotAct2 : MonoBehaviour
{
    //int plot = 0;
    public int currentStep = 0;
    private SpacePlot spacePlot;
    // Use this for initialization
    void Start()
    {
        spacePlot = GetComponent<SpacePlot>();
        Invoke("BeginPlot", 1f);
    }
    void BeginPlot()
    {
        CallPlotStep(++currentStep);
    }
    public void NextStep(int jump = 1, int current = -1)
    {
        Debug.Log(currentStep);
        if (current == -1) currentStep = currentStep + 1;
        else currentStep = current + jump;
        CallPlotStep(currentStep);
    }
    public void CallPlotStep(int stepNumber)
    {
        switch (stepNumber)
        {
            case 1:
                spacePlot.Blood();
                break;
            
            default:

                break;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
