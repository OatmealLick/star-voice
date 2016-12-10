using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipPlayer : MonoBehaviour {

    AudioSource source;
    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void Blood()
    {
        source.PlayOneShot((AudioClip)Resources.Load("Blood"), 1);
    }
    public void WTF()
    {
        source.PlayOneShot((AudioClip)Resources.Load("WTF"), 1);
    }
    public void Speaker()
    {
        source.PlayOneShot((AudioClip)Resources.Load("Critical_situation"), 1);
    }
    public void Stars()
    {
        source.PlayOneShot((AudioClip)Resources.Load("Stars"), 1);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
