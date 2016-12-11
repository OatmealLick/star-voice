using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {

    }

    public static void AttackWithKnife()
    {
        GameObject knife = GameObject.Find("Knife(Clone)");
        Animator knifeAnimator = knife.GetComponent<Animator>();
        knifeAnimator.SetTrigger("Attack");
        //ForestPlayer player = GameObject.Find("AudioSource").GetComponent<ForestPlayer>();
       // player.BearAttack();
    }
    public static void Shoot()
    {
        GameObject pac = (GameObject)Instantiate(Resources.Load("Pac"));
        pac.transform.SetParent(GameObject.Find("Canvas").transform, false);
        //ForestPlayer player = GameObject.Find("AudioSource").GetComponent<ForestPlayer>();
       // player.BearAttack();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
