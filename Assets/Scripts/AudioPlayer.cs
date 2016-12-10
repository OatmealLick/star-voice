using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    AudioSource source;
    AudioClipsLibrary library;
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        library = new AudioClipsLibrary();
        Forest();
	}
	
    public void Forest(){
        AudioClip clip;
        library.audioClips.TryGetValue("forest", out clip);
        source.clip = clip;
        source.Play();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
