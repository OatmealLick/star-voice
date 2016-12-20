using System;
using UnityEngine;
	
public class PlotPiece {
	//TODO add text position

	// 0 for staying forever - choices
	//public float pieceDisplayTime = 0f; 

	// if Length > 1, it's a choice PlotPiece
	public string[] texts;

	public TextAppear.TextSpeed speakerSpeed = TextAppear.TextSpeed.NORMAL;

	// ~characters per second
	//public float textDisplaySpeed = 13;

	public GameObject background;

	public bool keepOldBackground = false;

	public PlotPiece (string text) {
		texts = new string[] { text };
	}

	public PlotPiece (string[] texts) {
		this.texts = texts;
	}

	public bool isChoice() {
		return texts.Length > 1;
	}
		
}


