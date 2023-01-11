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
    public int currentWeapon = 0;
    public SoundEffectsManager manager;
    private Pack stuff;



    // Start is called before the first frame update
    void Start()
    {
        stuff = GetComponent<Pack>();
        anim = sword.GetComponent<Animator>();
        selectWeapon(-1);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentWeapon == 0) canAttack = true;
        else canAttack = false;

        if(Input.GetKeyDown("1") && stuff.checkIfCollected(1))   selectWeapon(0);

        if(Input.GetKeyDown("2") && stuff.checkIfCollected(2))   selectWeapon(1);

        if(Input.GetKeyDown("3") && stuff.checkIfCollected(3))   selectWeapon(2);

        if(Input.GetMouseButtonUp(0)){
            if(canAttack)   swordAttack();
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

    private void selectWeapon(int swap){
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(false);
        }

        if(swap == -1)  return;
        transform.GetChild(swap).gameObject.SetActive(true);
    }
}
