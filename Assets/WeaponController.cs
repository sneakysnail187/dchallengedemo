using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public GameObject sword;
    public GameObject shrinkRay;
    public GameObject controller;
    public bool canAttack = true;
    public Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        Animator anim = sword.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0)){
            if(canAttack){
                swordAttack();
            }
        }
        else{
            anim.SetBool("Attack", false);
        }
    }

    public void swordAttack(){
        anim.SetBool("Attack", true);
    }
}
