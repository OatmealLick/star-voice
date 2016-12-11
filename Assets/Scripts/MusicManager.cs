﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    AudioSource source;
    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().name == "Main") { source.clip = (AudioClip)Resources.Load("Forest_music"); }
        else source.clip = (AudioClip)Resources.Load("Creepy_ambience");
        source.loop = true;
        source.Play();
    }
    public void Fight()
    {
        source.clip = (AudioClip)Resources.Load("fight!");
        source.loop = true;
        source.Play();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
