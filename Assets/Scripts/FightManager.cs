using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FightManager : MonoBehaviour
{
	// these serve as health for hero and opponent
	public int hitsToKill = 3;
	public int hitsToDie = 3;

	// time to react for an attack
	// lower to make fight harder
	public float attackSpeedInSeconds = 3f;

	// delay after which fight starts after instantiating this
	public float delay = 0f;

	// self explanatory
	public float offsetBetweenSingleFights = 2f;

	// variables to manage fight states
	private bool fightInProgress = false;
	private bool startFight = false;

	// it contains awaiting attack
	// attacks are called with time offset (offsetBetweenSingleFights)
	// co holds the attack to launch it in exact moment
	private Coroutine co;

	// battle-specific GameObjects
	// to be set while instantiating this!
	public GameObject opponent;
	public GameObject weapon;

	// used to fire up attack animations
	// automatically obtained from passed weapon GameObject therefore
	// passed object has to have Animator with Attack bool Trigger
	private Animator weaponAnimator;

	// prefab containing lost-fight-screen
	public GameObject endPrefab;

	// single Fight instance prefab
	private GameObject fightPrefab;

	// AudioSource from PlotMachine
	private AudioSource audioSource;

	// sound data for attacks
	public AudioClip youHit;
	public AudioClip opponentHit;

	public PlotHandler plotHandler;


	// these below are used to pass info about winner back to calling Plot with 

	// basically custom type of events
	public delegate void BattleResult();

	// specific events Plot can register a listener to
	public static event BattleResult WonBattle;
	public static event BattleResult LostBattle;


	// Use this for initialization
	void Start () {
		// register Listeners for events FightWon & FightLost
		// WonSingleFight method will be called when FightWon event occurs
		// LostSingleFight method will be called when FightLost event occurs
		FightInstance.FightWon += WonSingleFight;
		FightInstance.FightLost += LostSingleFight;

		// Load single fight instance prefab from Resources
		fightPrefab = (GameObject)Resources.Load ("Fight");

		// if user didn't specify any new End screen in inspector
		// load default "This can't be an end prefab"
		if(endPrefab==null)
			endPrefab = (GameObject)Resources.Load ("TheEnd");

		// start fighting after the certain delay
		// if not specified, start immediately
		if (Mathf.Abs(delay) < .001f)
			startFight = true;
		else
			Invoke ("EnableFighting", delay);

		plotHandler = GameObject.Find ("PlotMachine").GetComponent<PlotHandler> ();

		// properly attach opponent and weapon GameObjects to correct Canvas
		// this double Canvas technic avoids UI being overlapped by background images
		Transform renderCanvasTr = GameObject.Find ("SecondCanvas").transform;
//		if(opponent!= null)
//			opponent.transform.SetParent (renderCanvasTr, false);
		if (weapon != null) {
			weapon.transform.SetParent (renderCanvasTr, false);

			// obtain Animator from passed weapon
			weaponAnimator = weapon.GetComponent<Animator> ();
		}

		// obtain AudioSource from the Scene and play Fight!
		audioSource = GameObject.Find("PlotMachine").GetComponent<AudioSource> ();
		AudioClip fight = (AudioClip)Resources.Load ("fight!");
		if (audioSource.clip != fight || !audioSource.isPlaying) {
			audioSource.clip = fight;
			audioSource.volume = 0.6f;
			audioSource.Play ();
		}
	}

	// Update is called once per frame
	void Update () {
		if (startFight && !fightInProgress) {
			fightInProgress = true;
			// save an attack as a coroutine
			co = StartCoroutine(DelayInstantiateFight(attackSpeedInSeconds, offsetBetweenSingleFights));
		}
	}

	// this is called after specified delay
	void EnableFighting() {
		startFight = true;
	}

	// delaying single fights with help of IEnumerator
	IEnumerator DelayInstantiateFight(float attackSpeed, float delayOffset) {
		yield return new WaitForSeconds (delayOffset);
		InstantiateFight (attackSpeed);
	}

	void InstantiateFight(float attackSpeed) {
		GameObject fight = Instantiate (fightPrefab);

		// optimization trick: if attack speed isn't changed from the default which is 3 seconds
		// there is no need to call GetComponent and give work to CPU
		if (Mathf.Abs(attackSpeed - 3f) < .001f) {
			fight.GetComponent<FightInstance> ().time = attackSpeed;
		}
	}

	void WonSingleFight() {
		Debug.Log ("FightManager - won single fight");
		fightInProgress = false;
		--hitsToKill;

		if(weaponAnimator!=null)
			weaponAnimator.SetTrigger ("Attack");

		if (youHit != null)
			audioSource.PlayOneShot (youHit);

		if (hitsToKill <= 0) {
			// you killed your opponent, won the whole battle
			startFight = false;
			WonTheWholeBattle ();
		}
	}
		
	void LostSingleFight() {
		Debug.Log ("FightManager - lost single fight");
		fightInProgress = false;
		--hitsToDie;

		if(weaponAnimator!=null)
			weaponAnimator.SetTrigger ("OpponentAttack");

		if (opponentHit != null)
			audioSource.PlayOneShot (opponentHit);

		if (hitsToDie <= 0) {
			// you died, lost whole battle
			startFight = false;
			LostTheWholeBattle();
		}
	}
		
	void WonTheWholeBattle() {
		Debug.Log ("FightManager - Won the whole battle");
		Destroy (opponent);
		Destroy (weapon);
		StopCoroutine (co);
		WonBattle ();
		plotHandler.isDisplaying = false;
		Destroy (gameObject);
	}

	void LostTheWholeBattle() {
		Debug.Log("FightManager - Lost the whole battle");

		// put up end screen
		GameObject endInstance = (GameObject)Instantiate(endPrefab);
		endInstance.transform.SetAsFirstSibling();
		endInstance.transform.SetParent(GameObject.Find("SecondCanvas").transform, false);
		endInstance.AddComponent <TheEndLostBattleSelfDestruct> ();
		endInstance.name = "TheEnd";

		// TODO smart fix to destroy end screens automatically

		Destroy (opponent);
		Destroy (weapon);
		LostBattle ();
		Destroy (gameObject);
	}

	void OnDestroy() {
		FightInstance.FightWon -= WonSingleFight;
		FightInstance.FightLost -= LostSingleFight;
	}
}