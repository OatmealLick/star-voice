using System.Collections;
using UnityEngine;

public static class AudioFadeOut {

//	public static IEnumerator FadeOut (AudioSource audioSource, float fadeTime) {
//		FadeOut (audioSource, fadeTime, null, 0f);
//	}

	public static IEnumerator FadeOut (AudioSource audioSource, float fadeTime, AudioClip clipToPlay, float newVolume) {
		float startVolume = audioSource.volume;

		while (Mathf.Abs(audioSource.volume) > 0.001) {
			audioSource.volume -= startVolume * Time.deltaTime / fadeTime;

			yield return null;
		}

		audioSource.Stop ();
		audioSource.volume = startVolume;

		if (clipToPlay != null) {
			audioSource.clip = clipToPlay;
			audioSource.volume = newVolume;
			audioSource.Play ();
		}
	}
}
