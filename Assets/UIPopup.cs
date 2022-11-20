using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopup : MonoBehaviour
{
    public static GameObject mainCam;
    public static GameObject player;
    //stores whether we have overlapped with this trigger before
    public bool hasBeenOverlapped = false;
    //stores whether it is a first time entry
    public bool firstTimeEntry = true;
    //stores the GameObject containing the UI component teleporter help
    public GameObject UIComponentTeleporters;
    //stores the GameObject containing the welcome UI component
    public GameObject welcomeUI;
    //stores reference to player: player has a script that controls his speed
    public GameObject playerSpeed;

    void Start(){
        mainCam = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");
        //set the welcome UI to active if first time
        if (firstTimeEntry){
            //set to active
            welcomeUI.SetActive(true);
            //set the Player speed to 0
            playerSpeed.GetComponent<FPSInput>().speed = 0f;
            //firstTimeEntry false
            firstTimeEntry = false;
            //pause functionality
            mainCam.GetComponent<MouseLook>().enabled = false;
            player.GetComponent<MouseLook>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    //this method is automatically called once movement starts ad player leaves trigger
    void OnTriggerExit (Collider other){

    if(other.GetComponent<Collider>().tag == "Player" && !hasBeenOverlapped){
        //set the UI to active
        UIComponentTeleporters.SetActive(true);
        //set hasBeenOverlapped to true
        hasBeenOverlapped = true;
        //timeScale 0
        //pause functionality
        Time.timeScale = 0f;
        mainCam.GetComponent<MouseLook>().enabled = false;
        player.GetComponent<MouseLook>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
  }

  //method to remove the UI
  //this method is called by a button push only
  public void removeUI(){

    //set the UI to inactive
    //set the UI to active
    UIComponentTeleporters.SetActive(false);
    welcomeUI.SetActive(false);
    //resume functionality
    //set the Player speed to normal
    playerSpeed.GetComponent<FPSInput>().speed = 6f;
    Time.timeScale = 1f;
    mainCam.GetComponent<MouseLook>().enabled = true;
    player.GetComponent<MouseLook>().enabled = true;
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
  }
}
