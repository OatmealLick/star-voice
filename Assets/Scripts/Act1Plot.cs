using UnityEngine;
using System.Collections;

public class Act1Plot : MonoBehaviour
{
	public PlotHandler plotHandler;
	public GameObject campfire;


	// Use this for initialization
	void Start ()
	{
		//TextAppear.readerSpeed = TextAppear.TextSpeed.HIGH;
		//default: speakerSpeed = NORMAL
		PlotPiece p1 = new PlotPiece ("A dark forest. You are surrounded by trees rustling on a gentle breeze. There's no one around you.");
		p1.speakerSpeed = TextAppear.TextSpeed.NORMAL;
		p1.textPosition = TextPosition.UP;
		p1.background = campfire;
		PlotPiece p2 = new PlotPiece ("you waaaaaaaaaaaaaaaaaaaaaalk and walk and walk");
		p2.keepOldBackground = false;
		p2.textPosition = TextPosition.BOTTOM;
	


		plotHandler.Add (p1);
		plotHandler.Add (p2);

		PlotPiece p3 = new PlotPiece (new string[] {
			"Go left",
			"Go vertically wrong"
		});


		plotHandler.Add (p3, new ChoicesBehaviour.ChoiceCallbacks[] {
			GoLeft, GoWrong
		});
			
	}

	void GoLeft() {
		Debug.Log ("LEFTTTT");
	}

	void GoWrong() {
		Debug.Log ("NOOOOOOOOO");
	}

	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

