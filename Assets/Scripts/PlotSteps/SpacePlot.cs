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
		Invoke ("AreWeInSpace", plotTimer);
	}

	public void AreWeInSpace() {
		spaceshipPlayer.Stars ();
		plotTimer = 10f;
		DisplayText(26, 20);
		Invoke ("Ekhem", plotTimer);
	}

	public void Ekhem() {
		plotTimer = 5f;
		DisplayText(27, 20);
		Invoke ("AManIsStanding", plotTimer);
	}

	public void AManIsStanding() {

		plotTimer = 10f;
		DisplayText(28, 20);
        ShowCommander();
		Invoke ("AManIsStanding", plotTimer);
	}
    public void ShowCommander()
    {
        GameObject corridor = (GameObject)Instantiate(Resources.Load("Commander"));
        corridor.transform.SetParent(bgCanvas.transform, false);
    }
	public void Labs() {
		Destroy(GameObject.Find("Corridor(Clone)"));
		plotTimer = 10f;
		DisplayText(41, 20);
		Invoke ("WhatHappenedHere", plotTimer);
	}

	public void WhatHappenedHere() {
		plotTimer = 8f;
		DisplayText(42, 20);
		Invoke ("YouHearAnInhumanScreech", plotTimer);
	}

	public void YouHearAnInhumanScreech() {
		plotTimer = 14f;
		DisplayText(43, 20);
		Invoke ("YouHearAnInhumanScreech", plotTimer);
	}
		

	public void WhatsWrongWithHim() {
		plotTimer = 5f;
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
		bridgeOrLabs.choiceTexts = choiceLibrary.GetChoice(5);
		bridgeOrLabs.nextPlotSteps = 1;

		instantiatedChoice.transform.SetParent(renderCanvas.transform, false);
	}


    // Update is called once per frame
    void Update () {
		
	}
}
