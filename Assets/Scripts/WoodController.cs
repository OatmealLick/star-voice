using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodController : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
		
	}

	public static void AttackWithWood (){
       GameObject wood = GameObject.Find("Wood(Clone)");
       Animator woodAnimator = wood.GetComponent<Animator>();
       woodAnimator.SetTrigger("Attack");
    }
    public static void Pac(){
        GameObject pac = (GameObject)Instantiate(Resources.Load("Pac"));
        pac.transform.SetParent(GameObject.Find("Canvas").transform, false);
        
    }
    // Update is called once per frame
    void Update () {
		
	}
}
