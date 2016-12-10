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
        source.PlayOneShot((AudioClip)Resources.Load("where"), 1);
    }
    public void Walk(){
        source.PlayOneShot((AudioClip)Resources.Load("walk-forest"), 1);
    }
    public void IShouldGo(){
        source.PlayOneShot((AudioClip)Resources.Load("go-this-way"), 1);
    }
    public void WhoMay() {
        source.PlayOneShot((AudioClip)Resources.Load("who-may"), 1);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
