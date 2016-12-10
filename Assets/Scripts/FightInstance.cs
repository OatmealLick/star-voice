using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FightInstance : MonoBehaviour
{
	public GameObject timerPrefab;
	public GameObject buttonPrefab;


	public delegate void FightResult();
	public static event FightResult FightWon;
	public static event FightResult FightLost;

	private GameObject timer;
	private GameObject button;
	private string randomChar;
	private GameObject renderCanvas;

	private bool isFightWon = false;

	const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

	public float time = 3;

	// Use this for initialization
	void Start ()
	{
		renderCanvas = GameObject.Find ("Canvas");
		timer = Instantiate (timerPrefab, new Vector3(0, 200), Quaternion.identity);
		button = Instantiate (buttonPrefab, new Vector3(0, -200), Quaternion.identity);
		timer.transform.SetParent (renderCanvas.transform, false);
		button.transform.SetParent (renderCanvas.transform, false);

		randomChar = chars[Random.Range (0, chars.Length)].ToString();

		button.GetComponentInChildren<Text> ().text = randomChar;

		Invoke ("DestroyUIElements", time);
	}

	private void DestroyUIElements() {
		Destroy (timer);
		Destroy (button);
		if (isFightWon) {
			if (FightWon != null)
				FightWon ();
		} else {
			if (FightLost != null)
				FightLost ();
		}
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (randomChar.ToLower())) {
			CancelInvoke ();
			isFightWon = true;
			DestroyUIElements ();
		}
	}
}

