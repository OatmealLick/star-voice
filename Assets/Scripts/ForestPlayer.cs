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
    public void Campfire()
    {
        source.clip = (AudioClip)Resources.Load("fire");
        source.Play();
    }
    public void FinallyWarmth()
    {
        source.PlayOneShot((AudioClip)Resources.Load("freezing"), 1);
    }
    public void IAmAlone()
    {
        source.PlayOneShot((AudioClip)Resources.Load("All_alone"), 1);
    }
    public void HowTheHell()
    {
        source.PlayOneShot((AudioClip)Resources.Load("End_up_here"), 1);
    }
    public void ItCanWait()
    {
        source.PlayOneShot((AudioClip)Resources.Load("It_can_wait"), 1);
    }
    public void FarBetter()
    {
        source.PlayOneShot((AudioClip)Resources.Load("Far_better"), 1);
    }
    public void PleaseNo()
    {
        source.PlayOneShot((AudioClip)Resources.Load("Please_no"), 1);
    }
    public void Scary()
    {
        source.PlayOneShot((AudioClip)Resources.Load("Scary"), 1);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
