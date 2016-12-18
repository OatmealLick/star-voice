using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour
{
	public AudioSource source;

	public virtual void PlayOneShotWithArguments(AudioClip clip, int times) {
		source.PlayOneShot (clip, times);
	}
}

