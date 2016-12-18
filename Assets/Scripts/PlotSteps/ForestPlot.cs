using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForestPlot : MonoBehaviour {

    Canvas renderCanvas;
    Canvas bgCanvas;
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
    public GameObject wood;

	void Awake() {
        bgCanvas = (Canvas)GameObject.Find("Canvas").GetComponent<Canvas>();
        renderCanvas = (Canvas)GameObject.Find("SecondCanvas").GetComponent<Canvas>();
		defaultText = (GameObject)Resources.Load ("DefaultText");
        upperText = (GameObject)Resources.Load("UpperText");
		fightSystem = (GameObject)Resources.Load ("FightManager");
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
		bg.transform.SetParent (bgCanvas.transform, false);
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
		FightManager.WonBattle += WonWithBear;
		FightManager.LostBattle += LostWithBear;
        
        musicManager.GetComponent<MusicManager>().Fight();
        
        GameObject system = Instantiate(fightSystem);
        system.transform.SetAsFirstSibling();
		FightManager fightManager = system.GetComponent<FightManager>();
		fightManager.hitsToKill = 5;
		fightManager.hitsToDie = 2;
        fightManager.delay = 1;
		fightManager.offsetBetweenSingleFights = 0.3f;
		fightManager.attackSpeedInSeconds = 1.8f;
		fightManager.opponent = Instantiate (bear);
		fightManager.weapon = Instantiate (wood);
		fightManager.youHit = (AudioClip)Resources.Load ("Torch_attack");
		fightManager.youHitTimes = 2;
    }
    
	public void WonWithBear() {
		Debug.Log ("ForestPlot - Won whole battle with the bear");
		FightManager.WonBattle -= WonWithBear;
	}

	public void LostWithBear() {
		Debug.Log ("ForestPlot - Lost whole battle with the bear");
		FightManager.LostBattle -= LostWithBear;
		// Invoke this below
		Invoke("Invoker", 3.5f);
	}

	private void Invoker() {
		//TODO: smart fix to destroy automatically end screens

		// this GameObject will be always called like this
		// see: FightManager#LostTheWholeBattle
		Destroy(GameObject.Find ("TheEnd"));

		plot.NextStep (1, 6);
	}
}
