using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UIPopup : MonoBehaviour
{
    public static GameObject mainCam;
    public static GameObject player;
    //stores whether we have overlapped with this trigger before
    public bool hasBeenOverlapped = false;
    //stores whether it is a first time entry
    public bool firstTimeEntry = false;
    //stores the GameObject containing the UI component teleporter help
    public GameObject UIComponentTeleporters;
    //stores the GameObject containing the welcome UI component
    public GameObject welcomeUI;
    //stores reference to player: player has a script that controls his speed
    public GameObject playerSpeed;
    //reference to all four doors
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    //stores a reference to the SoundEffects manager
    public SoundEffectsManager manager;
    //stores a reference to the Audio Manager  
    public Audiomanager2 musicManager;
    public GameObject gunUI;
	  public GameObject swordUI;
	  public GameObject controllerUI;
  
    //stores whether the player is currently searching for the teleporters
    public bool isSearching = false;

    void Start(){
        mainCam = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");
        //set the welcome UI to active if first time
        if (firstTimeEntry){
            //set to active
            welcomeUI.SetActive(true);
            //playUI POPUP SOUND
            manager.play("PopUp");
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

    //this method is automatically called once movement starts and player leaves trigger
    void OnTriggerExit (Collider other){
      //player is currently searching foe the teleporters. 
      isSearching = true;
      //you can only run this if the trigger has not been overlapped yet.
    if(other.GetComponent<Collider>().tag == "Player" && !hasBeenOverlapped){
        //set the UI to active
        UIComponentTeleporters.SetActive(true);
        //playUI POPUP SOUND
        manager.play("PopUp");
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
    //close doors dramatically if player is searching for teleporters
    if(isSearching){
      //door.doorHandler.closeDoor()
      door1.GetComponent<doorHandler>().closeDoor();
      door2.GetComponent<doorHandler>().closeDoor();
      door3.GetComponent<doorHandler>().closeDoor();
      door4.GetComponent<doorHandler>().closeDoor();
      //dramatic music
      musicManager.play("CommonsUpbeat");
      //turn off all other sounds
      musicManager.stop("CommonsEerie1");
      musicManager.stop("CommonsEerie2");
      isSearching = false;
    }
    //set the UI to inactive
    UIComponentTeleporters.SetActive(false);
    welcomeUI.SetActive(false);
    gunUI.SetActive(false);
    swordUI.SetActive(false);
    controllerUI.SetActive(false);
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
