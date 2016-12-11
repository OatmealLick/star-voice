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
        SpaceshipPlayer player = GameObject.Find("Audio Source").GetComponent<SpaceshipPlayer>();
        player.KnifeAttack();
    }

    public static void Shoot()
    {
        GameObject splat = (GameObject)Instantiate(Resources.Load("Splat"));
        splat.transform.SetParent(GameObject.Find("Canvas").transform, false);
        //ForestPlayer player = GameObject.Find("AudioSource").GetComponent<ForestPlayer>();
       // player.BearAttack();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
