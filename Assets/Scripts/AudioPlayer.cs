using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    AudioSource source;
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        Forest();
	}
	
    public void Forest(){
		source.clip = (AudioClip)Resources.Load("forest");
		source.loop = true;
        source.Play();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
