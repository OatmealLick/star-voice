using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForestPlot : MonoBehaviour {

    Canvas renderCanvas;
    private float plotTimer = 0.0f;
    private int currentStep = 1;
	private Plot plot;
    public AudioSource audioSource;
    ForestPlayer forestPlayer;
	private GameObject defaultText;
    private GameObject upperText;
    public GameObject scriptManager;
    public TextLibrary textLibrary;
    public ChoiceLibrary choiceLibrary;
    public GameObject choices;
    public Image background;

	void Awake() {
		renderCanvas = (Canvas)GameObject.Find("Canvas").GetComponent<Canvas>();
		defaultText = (GameObject)Resources.Load ("DefaultText");
        upperText = (GameObject)Resources.Load("UpperText");
        textLibrary = scriptManager.GetComponent<TextLibrary>();
        choiceLibrary = scriptManager.GetComponent<ChoiceLibrary>();
	}

	void Start() {
		plot = GetComponent<Plot> ();
        forestPlayer = audioSource.GetComponent<ForestPlayer>();
        //Debug.Log (defaultText);
    }

    public void DisplayText(int lineNumber, int readerSpeed){
        GameObject textParent = Instantiate(defaultText, new Vector3(0, 0), transform.rotation);
        TextAppear displayText = textParent.GetComponentInChildren<TextAppear>();
        displayText.readerSpeed = readerSpeed;
        textParent.transform.SetParent(renderCanvas.transform, false);
        displayText.SetText(textLibrary.GetLine(lineNumber));
    }
    public void DisplayUpperText(int lineNumber, int readerSpeed){
        GameObject textParent = Instantiate(upperText);
        TextAppear displayText = textParent.GetComponentInChildren<TextAppear>();
        displayText.readerSpeed = readerSpeed;
        textParent.transform.SetParent(renderCanvas.transform, false);
        displayText.SetText(textLibrary.GetLine(lineNumber));
    }
    public void ADarkForest(){
        plotTimer = 10f; // how long text will be on screen
        DisplayText(0, 15);
        Invoke("WhereAmI", plotTimer);
	}

    public void WhereAmI() {
        plotTimer = 3.5f;
        forestPlayer.WhereAmI();
        DisplayText(1, 15);
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
        plotTimer = 9f;
        DisplayText(2, 23);
        Invoke("IShouldGo", plotTimer);
    }

    public void Walk()
    {
        plotTimer = 10f;
        forestPlayer.Walk();
        DisplayText(6, 25);
        Invoke("WhoMay", plotTimer);
    }

    public void IShouldGo(){
        plotTimer = 4f;
        forestPlayer.IShouldGo();
        DisplayText(3, 20);
        Invoke("SomewhereDeep", plotTimer);
    }

    public void SomewhereDeep()
    {
        plotTimer = 5f;
        DisplayText(4, 15);
        Invoke("WhoMay", plotTimer);
    }

    public void WhoMay()
    {
        plotTimer = 4f;
        forestPlayer.WhoMay();
        DisplayText(5, 20);
        Invoke("FireApproach", plotTimer);
    }

    public void FireApproach()
    {
        plotTimer = 10f;
        forestPlayer.Campfire();
        DisplayUpperText(7, 20);
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