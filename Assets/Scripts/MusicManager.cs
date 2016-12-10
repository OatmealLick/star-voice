using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    AudioSource source;
    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = (AudioClip)Resources.Load("music");
        source.loop = true;
        //source.Play();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
