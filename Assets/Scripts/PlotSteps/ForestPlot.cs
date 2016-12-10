using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestPlot : MonoBehaviour {

    Canvas renderCanvas;
    private float plotTimer = 0.0f;
    private int currentStep = 1;
	private Plot plot;
    public AudioSource audioSource;
    ForestPlayer forestPlayer;
	private GameObject defaultText;
    public GameObject scriptManager;
    public TextLibrary textLibrary;
    public ChoiceLibrary choiceLibrary;
    public GameObject choices;

	void Awake() {
		renderCanvas = (Canvas)GameObject.Find("Canvas").GetComponent<Canvas>();
		defaultText = (GameObject)Resources.Load ("DefaultText");
        textLibrary = scriptManager.GetComponent<TextLibrary>();
        choiceLibrary = scriptManager.GetComponent<ChoiceLibrary>();
	}

	void Start() {
		plot = GetComponent<Plot> ();
        forestPlayer = audioSource.GetComponent<ForestPlayer>();
        //Debug.Log (defaultText);
    }

    public void ADarkForest(){
        plotTimer = 10f; // how long text will be on screen

		GameObject textParent = Instantiate (defaultText);
        TextAppear displayText = textParent.GetComponentInChildren<TextAppear>();
        textParent.transform.SetParent(renderCanvas.transform, false);
        displayText.SetText(textLibrary.GetLine(0));
        Invoke("WhereAmI", plotTimer);
	}

    public void WhereAmI() {
        plotTimer = 4f;
        forestPlayer.WhereAmI();
		GameObject textParent = Instantiate (defaultText);
        TextAppear displayText = textParent.GetComponentInChildren<TextAppear>();
        textParent.transform.SetParent(renderCanvas.transform, false);
        displayText.SetText(textLibrary.GetLine(1));
        Invoke("LookOrWalk", plotTimer);
    }

    public void LookOrWalk(){
        ChoicesBehaviour lookOrWalk = choices.GetComponent<ChoicesBehaviour>();
        lookOrWalk.choiceTexts = choiceLibrary.GetChoice(0);
        lookOrWalk.nextPlotSteps = 1;
        GameObject instantiatedChoice = Instantiate(choices);
        instantiatedChoice.transform.SetParent(renderCanvas.transform, false);
    }

    public void Look()
    {
        plotTimer = 4f;
        GameObject textParent = Instantiate(defaultText);
        TextAppear displayText = textParent.GetComponentInChildren<TextAppear>();
        textParent.transform.SetParent(renderCanvas.transform, false);
        displayText.SetText(textLibrary.GetLine(2));
       // Invoke("CallLookOrWalk", plotTimer);
    }

    public void Walk()
    {
        plotTimer = 4f;
        forestPlayer.Walk();
        GameObject textParent = Instantiate(defaultText);
        TextAppear displayText = textParent.GetComponentInChildren<TextAppear>();
        textParent.transform.SetParent(renderCanvas.transform, false);
        displayText.SetText(textLibrary.GetLine(6));
       // Invoke("CallLookOrWalk", plotTimer);
    }

    private void CallWhereAmI() {
		plot.CallPlotStep (++currentStep);
	}
    private void CallLookOrWalk()
    {
        plot.CallPlotStep(++currentStep);
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