using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForestPlot : MonoBehaviour {

    Canvas renderCanvas;
    private float plotTimer = 0.0f;
    //private int currentStep = 1;
	private Plot plot;
    public AudioSource audioSource;
    ForestPlayer forestPlayer;
	private GameObject defaultText;
    private GameObject upperText;
    public GameObject scriptManager;
    public TextLibrary textLibrary;
    public ChoiceLibrary choiceLibrary;
    public GameObject choices;
	public GameObject background;
    public GameObject fightSystem;
    public GameObject bear;
    public GameObject musicManager;

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
		textParent.transform.SetAsFirstSibling ();
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
		Invoke ("ShowCampfire", 3f);
    }

	private void ShowCampfire() {
		GameObject bg = Instantiate (background);
		bg.transform.SetParent (renderCanvas.transform, false);
	}

    public void FireApproach()
    {
        plotTimer = 10f;
        forestPlayer.Campfire();
        DisplayUpperText(7, 20);
        Invoke("FinallySomeWarmth", 10f);
    }
    public void FinallySomeWarmth()
    {
        plotTimer = 5f;
        forestPlayer.FinallyWarmth();
        DisplayUpperText(8, 20);
        Invoke("SitOrGather", plotTimer);
    }
    public void SitOrGather(){
        ChoicesBehaviour sitOrGather = choices.GetComponent<ChoicesBehaviour>();
        sitOrGather.choiceTexts = choiceLibrary.GetChoice(1);
        sitOrGather.nextPlotSteps = 4;
        GameObject instantiatedChoice = Instantiate(choices);
        instantiatedChoice.transform.SetParent(renderCanvas.transform, false);
    }

    public void OnceYouSat()
    {
        plotTimer = 9f;
        DisplayUpperText(9, 20);
        Invoke("ImAllAlone", plotTimer);
    }

    public void ImAllAlone()
    {
        forestPlayer.IAmAlone();
        plotTimer = 10f;
        DisplayUpperText(10, 20);
        Invoke("YouAreImmersed", plotTimer);
    }
    public void YouAreImmersed()
    {
        plotTimer = 5f;
        DisplayUpperText(11, 20);
        Invoke("HowDidI", plotTimer);
    }
    public void HowDidI()
    {
        forestPlayer.HowTheHell();
        plotTimer = 10f;
        DisplayUpperText(12, 20);
        Invoke("Noise", plotTimer);
    }
    public void GatherWood()
    {
        plotTimer = 8f;
        DisplayUpperText(13, 20);
        Invoke("ItCanWait", plotTimer);

    }
    public void ItCanWait()
    {
        forestPlayer.ItCanWait();
        plotTimer = 8f;
        DisplayUpperText(14, 25);
        Invoke("YouBeginToGather", plotTimer);
    }   
    public void YouBeginToGather()
    {
        plotTimer = 12f;
        DisplayUpperText(15, 20);
        Invoke("FarBetter", plotTimer);
    }
    public void FarBetter()
    {
        forestPlayer.FarBetter();
        plotTimer = 10f;
        DisplayUpperText(16, 20);
        Invoke("Noise", plotTimer);
    }
    public void Noise()
    {
        forestPlayer.Scary();
        plotTimer = 10f;
        DisplayUpperText(17, 20);
        Invoke("GodPlease", plotTimer);
    }
    public void GodPlease()
    {
        forestPlayer.PleaseNo();
        plotTimer = 10f;
        DisplayUpperText(18, 20);
        Invoke("FightStart", plotTimer);
    }

    public void FightStart(){
        GameObject bearImage = Instantiate(bear);
        bear.transform.SetAsFirstSibling();
        bearImage.transform.SetParent(renderCanvas.transform, false);
        musicManager.GetComponent<MusicManager>().Fight();

        GameObject system = Instantiate(fightSystem);
        system.transform.SetAsFirstSibling();
        FightResultEventListener fightListener = system.GetComponent<FightResultEventListener>();
        //fightListener.delay();

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