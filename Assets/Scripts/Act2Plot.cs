using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Act2Plot : MonoBehaviour
{
	// drag this in inspector, PlotHanfler should be attached to the same GameObject as this script
	public PlotHandler plotHandler;

	// backgrounds and other resources
	// you can drag them from Prefabs folder onto inspector field
	// or
	// you can load them from Resources folder using Resources#Load
	public GameObject speaker;
	private GameObject fightSystem;
	public GameObject commander;
	public GameObject knife;
	public GameObject space;
	public GameObject bridgeOrLabs;
	public GameObject sun;

	private bool labsVisited = false;
	private bool bridgeVisited = false;

	void Awake () {
		fightSystem = (GameObject)Resources.Load ("FightManager");
	}

	// Use this for initialization
	void Start ()
	{
		PlotPiece p1 = new PlotPiece ("* Why... Why there is... so much... blood here. Is it... is it.... a knife in my hand? What is this, lying on the floor... A body?! *");
		p1.backgroundClip = (AudioClip)Resources.Load("Creepy_ambience");
		p1.eventClip = (AudioClip)Resources.Load ("Blood");
		plotHandler.Add (p1);

		PlotPiece p2 = new PlotPiece ("A dark corridor. A body of an unknown man lies beneath your feet. You breathe heavily. You feel pain. A faint light shines on your hands, all covered in blood.");
		plotHandler.Add (p2);

		PlotPiece p3 = new PlotPiece ("* What the hell?! *");
		p3.speakerSpeed = TextSpeed.HIGH;
		p3.eventClip = (AudioClip)Resources.Load ("WTF");
		plotHandler.Add (p3);

		SpeakerAnnouncement (); // p4

		PlotPiece p5 = new PlotPiece ("You slowly walk into the corridor. It splits into two ways.");
		p5.keepOldBackground = false;
		p5.background = bridgeOrLabs;
		plotHandler.Add (p5);

		PlotPiece p6 = new PlotPiece (new string[] {
			"To the bridge.",
			"To the labs."
		});


		plotHandler.Add (p6, new ChoicesBehaviour.ChoiceCallbacks[] {
			Bridge, Labs
		});
	}

	void SpeakerAnnouncement() {
		PlotPiece p4 = new PlotPiece ("- We have a critical situation, I repeat we have a critical situation. Everyone is to check in at the bridge, where proper procedures will be executed.");
		p4.eventClip = (AudioClip)Resources.Load ("Critical_situation");
		p4.background = Instantiate (speaker);
		plotHandler.Add (p4);
	}

	void Bridge() {
		bridgeVisited = true;

		PlotPiece p1 = new PlotPiece ("You walk through an empty and silent corridor. The sound of your footsteps bounces around the walls making you question if you’re the only one here.");
		p1.backgroundClipVolume = 0.09f;
		p1.backgroundClip = (AudioClip)Resources.Load ("Bridge");
		p1.keepOldBackgroundClip = false;
		plotHandler.Add (p1);

		PlotPiece p2 = new PlotPiece ("Following the signs you reach the bridge. Hundreds of lights cover the walls, but somehow it still seems too dark for you. When you enter the hall, you see a grand viewport on the opposite side.");
		plotHandler.Add (p2);

		PlotPiece p3 = new PlotPiece ("* Stars… are we… in space? *");
		p3.eventClip = (AudioClip)Resources.Load ("Stars");
		plotHandler.Add (p3);

		PlotPiece p4 = new PlotPiece ("- Ekhem!");
		plotHandler.Add (p4);

		PlotPiece p5 = new PlotPiece ("A man is standing in front of a big screen with thousands of symbols.");
		p5.keepOldBackground = false;
		p5.background = commander;
		plotHandler.Add (p5);

		PlotPiece p6 = new PlotPiece ("- I don’t know if you are aware, but we are under an ongoing situation. A critical situation.");
		p6.eventClipVolume = 1;
		p6.eventClip = (AudioClip)Resources.Load ("Dialog1");
		plotHandler.Add (p6);

		CommanderConversation ();
	}

	public void CommanderConversation() {
		PlotPiece p7 = new PlotPiece ("- Where are we?! Why I am here? What’s the situation?!");
		p7.eventClipVolume = 1;
		p7.eventClip = (AudioClip)Resources.Load ("Dialog2a");
		plotHandler.Add (p7);

		PlotPiece p8 = new PlotPiece ("- A situation is critical and certain procedures must be executed. Thankfully, we’ve got a procedure for every situation in here. Every. Situation.");
		p8.eventClipVolume = 1;
		p8.eventClip = (AudioClip)Resources.Load ("Dialog3");
		plotHandler.Add (p8);

		PlotPiece p9 = new PlotPiece ("- But what is it? Who am I? Can you answer me?");
		p9.eventClip = (AudioClip)Resources.Load ("Dialog4a");
		plotHandler.Add (p9);

		PlotPiece p10 = new PlotPiece ("- Answers are not a part of currently executed procedure. It must be finished first.");
		p10.eventClip = (AudioClip)Resources.Load ("Dialog5");
		plotHandler.Add (p10);

		PlotPiece p11 = new PlotPiece ("* Is he mad? *");
		p11.eventClip = (AudioClip)Resources.Load("Is_he_mad");
		plotHandler.Add (p11);

		PlotPiece p12 = new PlotPiece ("* Is there a reason to even talk to him? *");
		p12.eventClip = (AudioClip)Resources.Load("Kill_him");
		plotHandler.Add (p12);

		PlotPiece p13 = new PlotPiece ("* Is there? *");
		p13.eventClip = (AudioClip)Resources.Load ("Is_there");
		plotHandler.Add (p13);

		PlotPiece p14 = new PlotPiece (new string[] {
			"There is.",
			"There is not."
		});
			
		plotHandler.Add (p14, new ChoicesBehaviour.ChoiceCallbacks[] {
			CommanderConversation, CommanderFight
		});
	}

	public void HeIsAHumanBeing() {
		PlotPiece p1 = new PlotPiece ("* He is a human being… Why would I kill him? *");
		p1.eventClip = (AudioClip)Resources.Load ("Human_being");
		plotHandler.Add (p1);

		CommanderFight ();
	}

	public void CommanderFight() {
		FightManager.WonBattle += WonWithCommander;
		FightManager.LostBattle += LostToCommander;

		//TODO think of something better, maybe split FightManager
		// to two classes, one handling MonoBehaviour timethings
		// and the other one containing data and counting points
		GameObject system = Instantiate(fightSystem);
		FightManager fightManager = system.GetComponent<FightManager>();
		fightManager.hitsToKill = 5;
		fightManager.hitsToDie = 2;
		fightManager.delay = 1;
		fightManager.offsetBetweenSingleFights = 1.3f;
		fightManager.attackSpeedInSeconds = 3.8f;
		fightManager.weapon = Instantiate (knife);
		fightManager.youHit = (AudioClip)Resources.Load ("Bear_attack");
		//fightManager.opponentHit = (AudioClip)Resources.Load ("Bear_attack");

		PlotPiece p1 = new PlotPiece (system);

		// Watch out! This is where enemy/opponent/background goes!
		// not as a part of fightManager

		//p1.background = bear;
		plotHandler.Add (p1);
	}

	public void WonWithCommander() {
		Debug.Log ("ForestPlot - Won whole battle with commander");
		FightManager.WonBattle -= WonWithCommander;
		FightManager.LostBattle -= LostToCommander;

		PlotPiece p1 = new PlotPiece ("* Why did I kill him? Did he attack first? What’s going on with my mind?! *");
		p1.keepOldBackground = false;
		p1.keepOldBackgroundClip = false;
		p1.backgroundClipVolume = 0.09f;
		p1.backgroundClip = (AudioClip)Resources.Load ("Bridge");
		p1.eventClip = (AudioClip)Resources.Load ("Did_I_kill_him");
		plotHandler.Add (p1);

		PlotPiece p2 = new PlotPiece ("You pass by the body of the commander and walk up to the screen that was behind him.");
		plotHandler.Add (p2);

		PlotPiece p3 = new PlotPiece ("* Just a little hint…. I need to know! *");
		p3.eventClip = (AudioClip)Resources.Load ("Mumble");
		plotHandler.Add (p3);

		PlotPiece p4 = new PlotPiece ("You cannot recognize most of the writing, but you can make out some of it...");
		plotHandler.Add (p4);

		PlotPiece p5 = new PlotPiece ("... course ABX765... \nLogdate 102 course stable... \nLogdate 123 course stable... \nLogdate 124 course not found... navigation system failure... \nLogdate 127 no course chosen... \nLogdate 130 no course chosen...");
		plotHandler.Add (p5);

		PlotPiece p6 = new PlotPiece ("... Red alert… … All crew members are to report on bridge… ...Danger...");
		plotHandler.Add (p6);

		PlotPiece p7 = new PlotPiece ("* What does it mean? *");
		p7.eventClip = (AudioClip)Resources.Load("Why_does_it_matter");
		plotHandler.Add (p7);

		PlotPiece p8 = new PlotPiece ("You climbed the bridge. The universe lies beneath your feet. Doesn't it?");
		p8.background = space;
		plotHandler.Add (p8);

		PlotPiece p9 = new PlotPiece ("No matter how hard you try, you can’t make sense out of the things you are seeing.");
		plotHandler.Add (p9);

		if (!labsVisited) {
			PlotPiece p10 = new PlotPiece ("* Maybe the labs will give me some answers... *");
			p10.eventClip = (AudioClip)Resources.Load("Maby_the_labs");
			plotHandler.Add (p10);

			YouHeadedIntoLabs ();
		} else {
			SceneManager.LoadScene ("End");
		}

	}

	public void LostToCommander() {
		Debug.Log ("ForestPlot - Lost whole battle with the bear");
		FightManager.WonBattle -= WonWithCommander;
		FightManager.LostBattle -= LostToCommander;
		Invoke ("CommanderFight", 3f);

		//TODO FIX ME Destroy(GameObject.Find ("TheEnd"));
	}

	void YouHeadedIntoLabs() {
		PlotPiece p1 = new PlotPiece ("You headed into the labs.");
		plotHandler.Add (p1);

		Labs ();
	}

	void Labs() {
		labsVisited = true;

		PlotPiece p1 = new PlotPiece ("A broken sliding door blocks the entrance to the laboratories. You pry it open. Dents cover the walls of a brightly lit room. Pieces of sterile, white tiles and equipment are all over the floor.");
		p1.keepOldBackgroundClip = false;
		p1.keepOldBackground = false;
		p1.backgroundClip = (AudioClip)Resources.Load ("Labs");
		p1.backgroundClipVolume = 0.5f;
		plotHandler.Add (p1);

		PlotPiece p2 = new PlotPiece ("* What happened here? *");
		p2.eventClipVolume = 1;
		p2.eventClip = (AudioClip)Resources.Load ("More_like_it");
		plotHandler.Add (p2);

		PlotPiece p3 = new PlotPiece ("You hear an inhuman screech coming from the distance. It’s getting closer. A fire extinguisher comes flying through a door. A man busts into the room with a crazed look in his eyes, forehead all covered in bloody scars.");
		p3.eventClip = (AudioClip)Resources.Load ("Scary");
		plotHandler.Add (p3);

		PlotPiece p4 = new PlotPiece ("* What’s wrong with him !? *");
		p4.eventClip = (AudioClip)Resources.Load ("Come_at_me");
		plotHandler.Add (p4);

		PlotPiece p5 = new PlotPiece ("He lets out a horrifying scream and charges right at you. You see an isolation cell on the left.");
		p5.eventClip = (AudioClip)Resources.Load ("Scream");
		p5.eventClipDelay = 1.7f;
		plotHandler.Add (p5);

		PlotPiece p6 = new PlotPiece (new string[] {
			"Run into the cell.",
			"Fight."
		});

		plotHandler.Add (p6, new ChoicesBehaviour.ChoiceCallbacks[] {
			Run, Fight
		});

		//WhoMayThatBe ();
	}

	void Run() {
		FightManager.WonBattle += RanFromHim;
		FightManager.LostBattle += DidntRun;

		GameObject system = Instantiate(fightSystem);
		FightManager fightManager = system.GetComponent<FightManager>();
		fightManager.hitsToKill = 2;
		fightManager.hitsToDie = 2;
		fightManager.delay = 1;
		fightManager.offsetBetweenSingleFights = 1.3f;
		fightManager.attackSpeedInSeconds = 1.8f;
		fightManager.endPrefab = (GameObject) Resources.Load ("Ralik");

		PlotPiece p1 = new PlotPiece (system);

		// Watch out! This is where enemy/opponent/background goes!
		// not as a part of fightManager

		//p1.background = HERE_GOES_YOUR_BACKGROUND;
		plotHandler.Add (p1);
	}

	void Fight() {
		Run ();
	}

	void DidntRun() {
		FightManager.WonBattle -= RanFromHim;
		FightManager.LostBattle -= DidntRun;

		Invoke ("Run", 3f);
	}

	void RanFromHim() {
		FightManager.WonBattle -= RanFromHim;
		FightManager.LostBattle -= DidntRun;

		PlotPiece p1 = new PlotPiece ("You run into the cell at the last second. You slam the door behind you. You hear him charging at the door head first again and again. Suddenly you hear a crunch and everything goes silent. You feel sick.");
		p1.keepOldBackgroundClip = false;
		plotHandler.Add (p1);

		PlotPiece p2 = new PlotPiece ("You hear a silent wheeze behind you. You turn around to see a man curled up on the floor. You see extensive wounds all over his body.");
		plotHandler.Add (p2);

		PlotPiece p3 = new PlotPiece ("- It can’t be happening... We were meant to see what’s beyond...");
		p3.eventClipVolume = 1;
		p3.speakerSpeed = TextSpeed.LOW;
		p3.eventClip = (AudioClip)Resources.Load("Dialog21");
		plotHandler.Add (p3);

		PlotPiece p4 = new PlotPiece ("- Beyond what? What’s going on in here?");
		p4.eventClip = (AudioClip)Resources.Load("Dialog22");
		plotHandler.Add (p4);

		PlotPiece p5 = new PlotPiece ("- We were prepared so well, but we never expected this…");
		p5.eventClip = (AudioClip)Resources.Load("Dialog23");
		p5.speakerSpeed = TextSpeed.LOW;
		plotHandler.Add (p5);

		PlotPiece p6 = new PlotPiece ("- What are you talking about?");
		p6.eventClip = (AudioClip)Resources.Load("Dialog24");
		plotHandler.Add (p6);

		PlotPiece p7 = new PlotPiece ("- Aah... the sun... I can feel the sun caressing my skin... The waves are taking me away...");
		p7.background = sun;
		p7.eventClip = (AudioClip)Resources.Load("Dialog25");
		p7.speakerSpeed = TextSpeed.LOW;
		plotHandler.Add (p7);

		if (!bridgeVisited) {
			PlotPiece p8 = new PlotPiece ("He breathes his last breath and an unobtrusive smile shines upon his face. Your chance to understand any of this fades away. Then you hear familiar sound:");
			plotHandler.Add (p8);

			SpeakerAnnouncement ();

			PlotPiece p9 = new PlotPiece ("You decide to visit bridge hoping to find answers.");
			p9.keepOldBackground = false;
			plotHandler.Add (p9);

			Bridge ();

		} else {
			SceneManager.LoadScene ("End");
		}
	}




}

