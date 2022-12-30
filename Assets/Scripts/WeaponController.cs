using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WeaponController : MonoBehaviour
{

    public GameObject sword;
    public GameObject shrinkRay;
    public GameObject controller;
    public bool canAttack = true;
    private Animator anim;
    public SoundEffectsManager manager;



    // Start is called before the first frame update
    void Start()
    {
        anim = sword.GetComponent<Animator>();
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
        //play sword sound
        manager.play("SwordAttack");
    }
}
