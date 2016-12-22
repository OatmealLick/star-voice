using System;
using UnityEngine;
	
public class PlotPiece {

	public TextPosition textPosition = TextPosition.CENTER;

	// if Length > 1, it's a choice PlotPiece
	public string[] texts;

	public TextSpeed speakerSpeed = TextSpeed.NORMAL;

	public GameObject background;

	public bool keepOldBackground = true;

	// AudioClips respectively to AudioSources in PlotHandler
	public AudioClip backgroundClip;
	public bool keepOldBackgroundClip = true;
	public float bacgroundClipVolume = 1f;

	public AudioClip eventClip;
	public float eventClipDelay = 0f;
	public float eventClipVolume = 1f;

	public AudioClip spareClip;
	public float spareClipDelay = 0f;
	public float spareClipVolume = 1f;

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


