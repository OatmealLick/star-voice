using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestPlayer : MonoBehaviour {

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
    public void WhereAmI(){
        source.PlayOneShot((AudioClip)Resources.Load("hallway"), 1);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
