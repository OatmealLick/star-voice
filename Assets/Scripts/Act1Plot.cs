using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Act1Plot : MonoBehaviour
{
	// drag this in inspector, PlotHanfler should be attached to the same GameObject as this script
	public PlotHandler plotHandler;

	// backgrounds and other resources
	// you can drag them from Prefabs folder onto inspector field
	// or
	// you can load them from Resources folder using Resources#Load
	public GameObject campfire;
	private GameObject fightSystem;
	public GameObject bear;
	public GameObject wood;

	void Awake () {
		fightSystem = (GameObject)Resources.Load ("FightManager");
	}

	// Use this for initialization
	void Start ()
	{
		PlotPiece p1 = new PlotPiece ("A dark forest. You are surrounded by trees rustling on a gentle breeze. There's no one around you.");
		p1.backgroundClip = (AudioClip)Resources.Load("Forest_music");
		plotHandler.Add (p1);

		PlotPiece p2 = new PlotPiece ("* Where am I? *");
		p2.eventClip = (AudioClip)Resources.Load ("where");
		plotHandler.Add (p2);

		PlotPiece p3 = new PlotPiece (new string[] {
			"Look around carefully.",
			"Start walking."
		});


		plotHandler.Add (p3, new ChoicesBehaviour.ChoiceCallbacks[] {
			LookAround, StartWalking
		});
	}

	void LookAround() {
		Debug.Log ("got it");
		PlotPiece p1 = new PlotPiece ("After a few moments of staring into the darkness, you see a tiny spark of light in the distance, almost invisible behind the wall of trees.");
		plotHandler.Add (p1);

		PlotPiece p2 = new PlotPiece ("* I should go this way. *");
		p2.speakerSpeed = TextSpeed.HIGH;
		p2.eventClip = (AudioClip)Resources.Load ("go-this-way");
		plotHandler.Add (p2);

		PlotPiece p3 = new PlotPiece ("Somewhere deep in the woods a fire is burning.");
		plotHandler.Add (p3);

		WhoMayThatBe ();
	}

	void StartWalking() {
		PlotPiece p1 = new PlotPiece ("You headed out into the darkness. At first you thought your confused mind is playing tricks on you, but then you were sure. There was a campfire somewhere in there.");
		p1.eventClip = (AudioClip)Resources.Load ("walk-forest");
		plotHandler.Add (p1);

		WhoMayThatBe ();
	}

	void WhoMayThatBe() {
		PlotPiece p1 = new PlotPiece ("* A campfire? Who may it be ? *");
		p1.keepOldBackgroundClip = false;
		p1.backgroundClip = (AudioClip)Resources.Load ("fire");
		plotHandler.Add (p1);

		PlotPiece p2 = new PlotPiece ("You approach the fire. It’s slowly dying down, but you are sure that somebody was here not a long time ago.");
		p2.background = campfire;
		p2.textPosition = TextPosition.UP;
		plotHandler.Add (p2);

		PlotPiece p3 = new PlotPiece ("* Finally some warmth, I was freezing... *");
		p3.eventClip = (AudioClip)Resources.Load ("freezing");
		p3.textPosition = TextPosition.UP;
		plotHandler.Add (p3);

		PlotPiece p4 = new PlotPiece (new string[] {
			"Sit and think.",
			"Start gathering wood to keep up the fire."
		});


		plotHandler.Add (p4, new ChoicesBehaviour.ChoiceCallbacks[] {
			SitAndThink, GatherWood
		});
	}

	void SitAndThink() {
		PlotPiece p1 = new PlotPiece ("Once you sat by the fire and calmed down your mind flooded with adrenaline, you began to realise what is going on.");
		p1.textPosition = TextPosition.UP;
		plotHandler.Add (p1);

		PlotPiece p2 = new PlotPiece ("* I’m all alone in this dark forest. I can’t recall anything from my past. Everything is spinning. I feel dizzy. *");
		p2.textPosition = TextPosition.UP;
		p2.eventClip = (AudioClip)Resources.Load ("All_alone");
		plotHandler.Add (p2);

		PlotPiece p3 = new PlotPiece ("You are immersed in your thoughts.");
		p3.textPosition = TextPosition.UP;
		plotHandler.Add (p3);

		PlotPiece p4 = new PlotPiece ("* How did I end up here? God, it’s so cold. I am so cold. *");
		p4.textPosition = TextPosition.UP;
		p4.eventClip = (AudioClip)Resources.Load ("End_up_here");
		plotHandler.Add (p4);

		HearNoise ();
	}

	void GatherWood() {
		PlotPiece p1 = new PlotPiece ("You calmed down your mind and began to gather firewood.");
		p1.textPosition = TextPosition.UP;
		plotHandler.Add (p1);

		PlotPiece p2 = new PlotPiece ("* It can wait. It all can wait. I will certainly freeze if I don't manage to keep up the fire. *");
		p2.textPosition = TextPosition.UP;
		p2.eventClip = (AudioClip)Resources.Load ("It_can_wait");
		plotHandler.Add (p2);

		PlotPiece p3 = new PlotPiece ("You began to gather firewood. Luckily it’s in no short supply. You threw it into the fire and soon a comforting crackle could be heard.");
		p3.textPosition = TextPosition.UP;
		plotHandler.Add (p3);

		PlotPiece p4 = new PlotPiece ("* Far better... now I can think... *");
		p4.eventClip = (AudioClip)Resources.Load ("Far_better");
		p4.textPosition = TextPosition.UP;
		plotHandler.Add (p4);

		HearNoise ();
	}

	void HearNoise() {
		PlotPiece p1 = new PlotPiece ("Suddenly, you’ve heard a noise. Something is coming your way. Something big.");
		p1.textPosition = TextPosition.UP;
		p1.eventClip = (AudioClip)Resources.Load("Scary");
		plotHandler.Add (p1);

		PlotPiece p2 = new PlotPiece ("* God, please, no… What is this? *");
		p2.textPosition = TextPosition.UP;
		p2.eventClip = (AudioClip)Resources.Load ("Please_no");
		plotHandler.Add (p2);

		BearFight ();
	}

	//TODO we gotta delay this maaan
	void BearFight() {

		FightManager.WonBattle += WonWithBear;
		FightManager.LostBattle += LostWithBear;

		GameObject system = Instantiate(fightSystem);
		system.transform.SetAsFirstSibling();
		FightManager fightManager = system.GetComponent<FightManager>();
		fightManager.hitsToKill = 5;
		fightManager.hitsToDie = 2;
		fightManager.delay = 1;
		fightManager.offsetBetweenSingleFights = 1.3f;
		fightManager.attackSpeedInSeconds = 1.8f;
		fightManager.opponent = Instantiate (bear);
		fightManager.weapon = Instantiate (wood);
		fightManager.youHit = (AudioClip)Resources.Load ("Torch_attack");
		fightManager.opponentHit = (AudioClip)Resources.Load ("Bear_attack");
	}

	public void WonWithBear() {
		Debug.Log ("ForestPlot - Won whole battle with the bear");
		FightManager.WonBattle -= WonWithBear;
		FightManager.LostBattle -= LostWithBear;
		SceneManager.LoadScene ("SpaceShip");
	}

	public void LostWithBear() {
		Debug.Log ("ForestPlot - Lost whole battle with the bear");
		FightManager.WonBattle -= WonWithBear;
		FightManager.LostBattle -= LostWithBear;
		Invoke ("BearFight", 3f);
	}

	
//	// Update is called once per frame
//	void Update ()
//	{
//	
//	}
}

