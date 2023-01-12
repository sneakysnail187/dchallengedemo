using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Victory_DefeatUI : MonoBehaviour
{
    //stores a reference to the canvas 
    public GameObject canvas;
    //stores whether we have overlapped with this trigger before
    public bool hasBeenOverlapped = false;
    //stores the number of points
    private int points;
    //stores the victory animator
    public Animator victoryAnim;
    //stores the defeat animator
    public Animator defeatAnim;

    // Start is called before the first frame update
    void Start()
    {
        //get the canvas
        canvas = GameObject.Find("Canvas");  
        //get the points
        points = int.Parse(canvas.transform.Find("CounterBorder").GetChild(0).GetChild(0).gameObject.GetComponent<TMP_Text>().text);  
        //get the animators
        victoryAnim = canvas.transform.Find("Victory").gameObject.GetComponent<Animator>();   
        defeatAnim = canvas.transform.Find("Death").gameObject.GetComponent<Animator>();
    }

    void Update(){
        //continuously get the points
        points = int.Parse(canvas.transform.Find("CounterBorder").GetChild(0).GetChild(0).gameObject.GetComponent<TMP_Text>().text);
    }

    // when this trigger is overlapped
    void OnTriggerEnter(Collider other){
        if(other.GetComponent<Collider>().tag == "Player" && !hasBeenOverlapped){
            //set the boolean
            hasBeenOverlapped = true;
            //start the animation sequence depending on the number of points
            if(points >= 90){
                //set the Object to active
                canvas.transform.Find("Victory").gameObject.SetActive(true);
                //start the victory animator
                victoryAnim.SetBool("startVictory", true);
                //victoryAnim.SetBool("endVictory", false);
            }
            else{
                //set the Object to active
                canvas.transform.Find("Death").gameObject.SetActive(true);
                //points are less than 90
                defeatAnim.SetBool("startDeath", true);
                
            }
        }
    }
}
