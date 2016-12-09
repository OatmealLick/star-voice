using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipsLibrary : MonoBehaviour {

    public Dictionary<string, AudioClip> audioClips;
	// Use this for initialization
	void Start () {
        audioClips.Add("forest", (AudioClip)Resources.Load("forest"));
        audioClips.Add("fire", (AudioClip)Resources.Load("fire"));
    }

    // Update is called once per frame
    void Update () {
		
	}
}
