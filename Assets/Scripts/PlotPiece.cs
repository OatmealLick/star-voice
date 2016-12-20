using System;
using UnityEngine;
	
public class PlotPiece {

	public TextPosition textPosition = TextPosition.CENTER;

	// if Length > 1, it's a choice PlotPiece
	public string[] texts;

	public TextAppear.TextSpeed speakerSpeed = TextAppear.TextSpeed.NORMAL;

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


