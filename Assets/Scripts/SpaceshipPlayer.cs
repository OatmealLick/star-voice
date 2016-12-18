using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipPlayer : AudioPlayer {

 
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
    public void Dialog(string n)
    {
        if (n == "1") source.PlayOneShot((AudioClip)Resources.Load("Dialog1"), 1);
        if (n == "2a") source.PlayOneShot((AudioClip)Resources.Load("Dialog2a"), 1);
        if (n == "2b") source.PlayOneShot((AudioClip)Resources.Load("Dialog2b"), 1);
        if (n == "3") source.PlayOneShot((AudioClip)Resources.Load("Dialog3"), 1);
        if (n == "4a") source.PlayOneShot((AudioClip)Resources.Load("Dialog4a"), 1);
        if (n == "4b") source.PlayOneShot((AudioClip)Resources.Load("Dialog4b"), 1);
        if (n == "5") source.PlayOneShot((AudioClip)Resources.Load("Dialog5"), 1);
    }
    public void Dialog2(string n)
    {
        if (n == "1") source.PlayOneShot((AudioClip)Resources.Load("Dialog21"), 1);
        if (n == "2") source.PlayOneShot((AudioClip)Resources.Load("Dialog22"), 1);
        if (n == "3") source.PlayOneShot((AudioClip)Resources.Load("Dialog23"), 1);
        if (n == "4") source.PlayOneShot((AudioClip)Resources.Load("Dialog24"), 1);
        if (n == "5") source.PlayOneShot((AudioClip)Resources.Load("Dialog25"), 1);
    }
    public void MoreLikeIt()
    {
        source.PlayOneShot((AudioClip)Resources.Load("More_like_it"), 1);
    }
    public void ComeAtMe()
    {
        source.PlayOneShot((AudioClip)Resources.Load("Come_at_me"), 1);
    }
    public void Scary()
    {
        source.PlayOneShot((AudioClip)Resources.Load("Scary"), 1);
    }
    public void Scream()
    {
        source.PlayOneShot((AudioClip)Resources.Load("Scream"), 1);
    }
    public void IsHeMad()
    {
        source.PlayOneShot((AudioClip)Resources.Load("Is_he_mad"), 1);
    }
    public void IsThereReason()
    {
        source.PlayOneShot((AudioClip)Resources.Load("Kill_him"), 1);
    }
    public void IsThere()
    {
        source.PlayOneShot((AudioClip)Resources.Load("Is_there"), 1);
    }
    public void OfCourse()
    {
        source.PlayOneShot((AudioClip)Resources.Load("Of_course"), 1);
    }
    public void HumanBeing()
    {
        source.PlayOneShot((AudioClip)Resources.Load("Human_being"), 1);
    }
    public void CorridorFootsteps()
    {
        source.PlayOneShot((AudioClip)Resources.Load("hallway"), 1);
    }
    public void KnifeAttack()
    {
        source.PlayOneShot((AudioClip)Resources.Load("Bear_attack"), 1);
    }
    public void DidIKillHim()
    {
        source.PlayOneShot((AudioClip)Resources.Load("Did_I_kill_him"), 1);
    }
    public void Mumble()
    {
        source.PlayOneShot((AudioClip)Resources.Load("Mumble"), 1);
    }
    public void WhyDoesItMatter()
    {
        source.PlayOneShot((AudioClip)Resources.Load("Why_does_it_matter"), 1);
    }
    public void MaybeTheLabs()
    {
        source.PlayOneShot((AudioClip)Resources.Load("Maby_the_labs"), 1); 
    }
    // Update is called once per frame
    void Update () {
		
	}
}
