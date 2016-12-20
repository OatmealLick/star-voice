using UnityEngine;
using System.Collections;

public class Act1Plot : MonoBehaviour
{
	public PlotHandler plotHandler;
	// Use this for initialization
	void Start ()
	{
		//default: speakerSpeed = NORMAL
		PlotPiece p1 = new PlotPiece ("A dark forest. You are surrounded by trees rustling on a gentle breeze. There's no one around you.");
		p1.speakerSpeed = TextAppear.TextSpeed.HIGH;
		PlotPiece p2 = new PlotPiece ("you waaaaaaaaaaaaaaaaaaaaaalk and walk and walk");
	
		plotHandler.Add (p1);
		plotHandler.Add (p2);
	}

	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

