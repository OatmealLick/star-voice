using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePlot : MonoBehaviour {

    Canvas renderCanvas;
	Canvas bgCanvas;
    private float plotTimer = 0.0f;
    //private int currentStep = 1;
    private Plot plot;
    public AudioSource audioSource;
    ForestPlayer forestPlayer;
    SpaceshipPlayer spaceshipPlayer;
    private GameObject defaultText;
    private GameObject upperText;
    public GameObject scriptManager;
    public TextLibrary textLibrary;
    public ChoiceLibrary choiceLibrary;
    public GameObject choices;
    public GameObject background;
    public GameObject fightSystem;
    public GameObject bg;
    public GameObject knife;
    public GameObject musicManager;
    // Use this for initialization
    void Awake()
    {
		bgCanvas = (Canvas)GameObject.Find("Canvas").GetComponent<Canvas>();
		renderCanvas = (Canvas)GameObject.Find("SecondCanvas").GetComponent<Canvas>();
        defaultText = (GameObject)Resources.Load("DefaultText");
        upperText = (GameObject)Resources.Load("UpperText");
        textLibrary = scriptManager.GetComponent<TextLibrary>();
        choiceLibrary = scriptManager.GetComponent<ChoiceLibrary>();
    }
    void Start () {
        spaceshipPlayer = audioSource.GetComponent<SpaceshipPlayer>();
	}
    public void DisplayText(int lineNumber, int readerSpeed)
    {
        GameObject textParent = Instantiate(defaultText, new Vector3(0, 0), transform.rotation);
        TextAppear displayText = textParent.GetComponentInChildren<TextAppear>();
        displayText.readerSpeed = readerSpeed;
        textParent.transform.SetParent(renderCanvas.transform, false);
        displayText.SetText(textLibrary.GetLine(lineNumber));
    }
    public void DisplayUpperText(int lineNumber, int readerSpeed)
    {
        GameObject textParent = Instantiate(upperText);
        TextAppear displayText = textParent.GetComponentInChildren<TextAppear>();
        displayText.readerSpeed = readerSpeed;
        textParent.transform.SetParent(renderCanvas.transform, false);
        displayText.SetText(textLibrary.GetLine(lineNumber));
        textParent.transform.SetAsFirstSibling();
    }

    public void Blood()
    {
        plotTimer = 12f;
        spaceshipPlayer.Blood();
       // MusicManager.WhereAmI();
        DisplayText(19, 18);
        Invoke("DarkCorridor", plotTimer);
    }
    public void DarkCorridor()
    {
        plotTimer = 12f;
        DisplayText(20, 22);
        Invoke("WTF", plotTimer);
    }

	public void WTF()
	{
		plotTimer = 4f;
		DisplayText(21, 20);
		spaceshipPlayer.WTF();
		Invoke("WeHaveACriticalSituation", plotTimer);
        Invoke("ShowSpeaker", 2f);
	}

    public void ShowSpeaker()
    {
        GameObject speaker = (GameObject) Instantiate(Resources.Load("Speaker"));
        speaker.transform.SetParent(bgCanvas.transform, false);
    }

	public void WeHaveACriticalSituation()
	{
		spaceshipPlayer.Speaker ();
		plotTimer = 15f;
		DisplayText(22, 20);
		Invoke("YouSlowlyWalkThroughCorridor", plotTimer);
	}

    public void ShowCorridor()
    {
        Destroy(GameObject.Find("Speaker(Clone)"));
        GameObject corridor = (GameObject)Instantiate(Resources.Load("Corridor"));
        corridor.transform.SetParent(bgCanvas.transform, false);
    }

    public void YouSlowlyWalkThroughCorridor()
	{
        plotTimer = 6f;
		DisplayText(23, 20);
		Invoke("BridgeOrLabs", plotTimer);
        ShowCorridor();
	}

	public void BridgeOrLabs() {
		GameObject instantiatedChoice = Instantiate(choices);
		ChoicesBehaviour bridgeOrLabs = instantiatedChoice.GetComponent<ChoicesBehaviour>();
		bridgeOrLabs.choiceTexts = choiceLibrary.GetChoice(4);
		bridgeOrLabs.nextPlotSteps = 1;

		instantiatedChoice.transform.SetParent(renderCanvas.transform, false);
	}

	public void Bridge() {
        Destroy(GameObject.Find("Corridor(Clone)"));
        plotTimer = 13f;
		DisplayText(24, 20);
        spaceshipPlayer.CorridorFootsteps();
		Invoke ("FollowingSigns", plotTimer);
	}

	public void FollowingSigns() {
		plotTimer = 15f;
		DisplayText(25, 20);
        musicManager.GetComponent<MusicManager>().Bridge();
		Invoke ("AreWeInSpace", plotTimer);
	}

	public void AreWeInSpace() {
		spaceshipPlayer.Stars ();
		plotTimer = 6f;
		DisplayText(26, 20);
		Invoke ("Ekhem", plotTimer);
	}

	public void Ekhem() {
		plotTimer = 3f;
		DisplayText(27, 20);
		Invoke ("AManIsStanding", plotTimer);
	}

	public void AManIsStanding() {

		plotTimer = 9f;
		DisplayText(28, 20);
        ShowCommander();
		Invoke ("IDontKnowIfYoureAware", plotTimer);
	}
    public void ShowCommander()
	{
		GameObject corridor = (GameObject)Instantiate (Resources.Load ("Commander"));
		corridor.transform.SetParent (bgCanvas.transform, false);
	}
	public void IDontKnowIfYoureAware() {
        spaceshipPlayer.Dialog("1");
        plotTimer = 8f;
		DisplayText (29, 20);
		Invoke ("WhereAreWe", plotTimer);
    }

	public void WhereAreWe() {
        spaceshipPlayer.Dialog("2a");
        plotTimer = 6f;
		DisplayText (30, 20);
		Invoke ("ASituationIsCritical", plotTimer);
	}

	public void ASituationIsCritical(){
        spaceshipPlayer.Dialog("3");
        plotTimer = 11.4f;
		DisplayText (31, 20);
		Invoke ("ButWhatIsIt", plotTimer);
	}

	public void ButWhatIsIt() {
        spaceshipPlayer.Dialog("4a");
        plotTimer = 4.5f;
		DisplayText (32, 20);
		Invoke ("AnswersAreNot", plotTimer);
	}

	public void AnswersAreNot() {
        spaceshipPlayer.Dialog("5");
        plotTimer = 7.4f;
		DisplayText (33, 20);
		Invoke ("IsHeMad", plotTimer);
	}

	public void IsHeMad() {
        spaceshipPlayer.IsHeMad();
        plotTimer = 3f;
		DisplayText (34, 20);
		Invoke ("IsThereAReason", plotTimer);
	}

	public void IsThereAReason() {
        spaceshipPlayer.IsThereReason();
        plotTimer = 5f;
		DisplayText (35, 20);
		Invoke ("IsThere", plotTimer);
	}

	public void IsThere() {
        spaceshipPlayer.IsThere();
        plotTimer = 3f;
		DisplayText (36, 20);
		Invoke ("ThereIsOrThereIsNot", plotTimer);
	}

	public void ThereIsOrThereIsNot() {
		GameObject instantiatedChoice = Instantiate(choices);
		ChoicesBehaviour bridgeOrLabs = instantiatedChoice.GetComponent<ChoicesBehaviour>();
		bridgeOrLabs.choiceTexts = choiceLibrary.GetChoice(5);
		bridgeOrLabs.nextPlotSteps = 3;
		instantiatedChoice.transform.SetParent(renderCanvas.transform, false);
	}

	public void ThereIs() {
		WhereAreWe ();
	}

	public void ThereIsNot() {
		Debug.Log ("EUREKA");
        HeIsAHuman();
    }

    public void HeIsAHuman()
    {
        spaceshipPlayer.HumanBeing();
        plotTimer = 8f;
        DisplayText(40, 20);
        Invoke("CommanderFight", plotTimer);   
    }
    public void CommanderAgain()
    {
        ShowCommander();
        CommanderFight();
    }
    public void CommanderFight()
    {
        GameObject knifeImage = Instantiate(knife);
        knifeImage.transform.SetParent(renderCanvas.transform, false);
        musicManager.GetComponent<MusicManager>().Fight();
        GameObject system = Instantiate(fightSystem);
        system.transform.SetAsFirstSibling();
        FightResultEventListenerCommander fightListener = system.GetComponent<FightResultEventListenerCommander>();
        fightListener.attackCount = 10;
        fightListener.health = 1;
        fightListener.delay = 1;
        fightListener.delaySingleFightInstance = 2.3f;
        fightListener.hitsToKill = 5;
        fightListener.timeForAttack = 1f;
    }

    public void WonWithCommander()
    {
        spaceshipPlayer.DidIKillHim();
        musicManager.GetComponent<MusicManager>().Bridge();

        plotTimer = 7f;
        DisplayText(53, 20);
        Invoke("PassByTheBody", plotTimer);
    }

    public void PassByTheBody()
    {
        plotTimer = 7f;
        DisplayText(54, 20);
        Invoke("LittleHint", plotTimer);
    }

    public void LittleHint()
    {
        spaceshipPlayer.Mumble();
        plotTimer = 6f;
        DisplayText(55, 20);
        Invoke("Recognize", plotTimer);
    }

    public void Recognize()
    {
        spaceshipPlayer.Mumble();
        plotTimer = 7f;
        DisplayText(56, 20);
        Invoke("Course", plotTimer);
    }

    public void Course()
    {
        plotTimer = 14f;
        DisplayText(57, 23);
        Invoke("RedAlert", plotTimer);
    }
    public void RedAlert()
    {
        plotTimer = 7f;
        DisplayText(58, 20);
        Invoke("WhatDoesItMean", plotTimer);
    }
    public void WhatDoesItMean()
    {
        spaceshipPlayer.WhyDoesItMatter();
        plotTimer = 6f;
        DisplayText(59, 20);
        Invoke("YouClimbed", plotTimer);
    }
    public void ShowSpace()
    {
        GameObject space = (GameObject)Instantiate(Resources.Load("Space"));
        space.transform.SetParent(bgCanvas.transform, false);
    }
    public void YouClimbed()
    {
        plotTimer = 12f;
        DisplayText(60, 20);
        Invoke("NoMatter", plotTimer);
        Invoke("ShowSpace", 1f);
    }
    public void NoMatter()
    {
        plotTimer = 12f;
        DisplayText(61, 20);
        Invoke("MaybeTheLabs", plotTimer);
    }
    public void MaybeTheLabs()
    {
        spaceshipPlayer.MaybeTheLabs();
        plotTimer = 5f;
        DisplayText(62, 20);
        Invoke("ToTheLabs", plotTimer);
    }

    public void ToTheLabs()
    {
        Destroy(GameObject.Find("Space(Clone)"));
        plotTimer = 5f;
        DisplayText(63, 20);
        Invoke("Labs", plotTimer);
    }

    public void Labs() {
        musicManager.GetComponent<MusicManager>().Labs();
		Destroy(GameObject.Find("Corridor(Clone)"));
		plotTimer = 16f;
		DisplayText(41, 20);
		Invoke ("WhatHappenedHere", plotTimer);
	}

	public void WhatHappenedHere() {
        spaceshipPlayer.MoreLikeIt();
        plotTimer = 5f;
		DisplayText(42, 20);
		Invoke ("YouHearAnInhumanScreech", plotTimer);
	}

	public void YouHearAnInhumanScreech() {
		plotTimer = 17f;
		DisplayText(43, 20);
		Invoke ("WhatsWrongWithHim", plotTimer);
	}
		

	public void WhatsWrongWithHim() {
        spaceshipPlayer.ComeAtMe();
        plotTimer = 4f;
		DisplayText(44, 20);
		Invoke ("HeLetsOutScream", plotTimer);
	}

	public void HeLetsOutScream() {
		plotTimer = 10f;
		DisplayText(45, 20);
		Invoke ("RunOrFaceHim", plotTimer);
	}
		
	public void RunOrFaceHim() {
		GameObject instantiatedChoice = Instantiate(choices);
		ChoicesBehaviour bridgeOrLabs = instantiatedChoice.GetComponent<ChoicesBehaviour>();
		bridgeOrLabs.choiceTexts = choiceLibrary.GetChoice(6);
		bridgeOrLabs.nextPlotSteps = 5;

		instantiatedChoice.transform.SetParent(renderCanvas.transform, false);
	}

	public void Run() {
		musicManager.GetComponent<MusicManager>().Fight();
		fightSystem = (GameObject) Resources.Load ("RUN_FIGHT_LISTENER");
		GameObject system = Instantiate(fightSystem);
		system.transform.SetAsFirstSibling();
		FightResultEventListenerRunning fightListener = system.GetComponent<FightResultEventListenerRunning>();
		fightListener.attackCount = 10;
		fightListener.health = 2;
		fightListener.delaySingleFightInstance = 1.3f;
		fightListener.hitsToKill = 6;
		fightListener.timeForAttack = 0.8f;
	}

	public void FaceHim() {
		Run ();
	}

	//TODO HOW TO GET HERE
	public void YouReachTheCell() {
		plotTimer = 16f;
		DisplayText(64, 20);
		Invoke ("YouHereASilentWeeze", plotTimer);
	}

	public void YouHereASilentWeeze() {
        musicManager.GetComponent<MusicManager>().Labs();
        plotTimer = 12f;
		DisplayText(65, 20);
		Invoke ("ItCantBeHappening", plotTimer);
	}

	public void ItCantBeHappening() {
        spaceshipPlayer.Dialog2("1");
        plotTimer = 12f;
		DisplayText(66, 10);
		Invoke ("BeyondWhat", plotTimer);
	}

	public void BeyondWhat() {
        spaceshipPlayer.Dialog2("2");
        plotTimer = 6.5f;
		DisplayText(67, 24);
		Invoke ("WePreparedWell", plotTimer);
	}

	public void WePreparedWell() {
        spaceshipPlayer.Dialog2("3");
        plotTimer = 10f;
		DisplayText(68, 10);
		Invoke ("WhatAreYouTalkingAbout", plotTimer);
	}

	public void WhatAreYouTalkingAbout() {
        spaceshipPlayer.Dialog2("4");
        plotTimer = 5f;
		DisplayText(69, 27);
		Invoke ("TheSun", plotTimer);
	}
    public void ShowSun()
    {
        GameObject sun = (GameObject)Instantiate(Resources.Load("Sun"));
        sun.transform.SetParent(bgCanvas.transform, false);
    }
    public void TheSun() {
        ShowSun();
        spaceshipPlayer.Dialog2("5");
        plotTimer = 23f;
		DisplayText(70, 10);
		//Invoke ("RunOrFaceHim", plotTimer);
	}


    // Update is called once per frame
    void Update () {
		
	}
}
