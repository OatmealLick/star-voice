using System.Collections;
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
        source.volume = 0.6f;
        source.Play();
    }
    public void Bridge()
    {
        source.clip = (AudioClip)Resources.Load("Bridge");
        source.loop = true;
        source.volume = 0.09f;
        source.Play();
    }
    public void Labs()
    {
        source.clip = (AudioClip)Resources.Load("Labs");
        source.loop = true;
        source.volume = 0.5f;
        source.Play();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
