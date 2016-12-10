using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePlot : MonoBehaviour {

    Canvas renderCanvas;
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
    // Use this for initialization
    void Awake()
    {
        renderCanvas = (Canvas)GameObject.Find("Canvas").GetComponent<Canvas>();
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
        plotTimer = 10f;
        DisplayText(20, 20);
        Invoke("DarkCorridor", plotTimer);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
