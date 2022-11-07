using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject canvas;
    public static GameObject mainCam;
    public static GameObject player;
    public static bool isPaused = false;
    public static bool AnswerTriggerFire;
    public static bool resumeCalled;
    
    void Start(){
        player = GameObject.Find("Player");
        canvas = GameObject.Find("Canvas");
        resumeCalled = false;
        AnswerTriggerFire = false;
        mainCam = GameObject.Find("Main Camera");
    }
    void Update(){
        //entering the collider
        if(AnswerTriggerFire){
            if(!isPaused){
                Pause(false);
                AnswerTriggerFire = false;
            }
        }
        //exiting the collider
        if(resumeCalled){
            Resume();
        }
        if(Input.GetKeyDown("escape")){
            if(isPaused){
                Resume();
            }
            else{
                Pause(true);
            }
        }
    }

    public void Pause(bool isQuit)
    {
        isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if(!isQuit){
            //AnswerUI
            canvas.transform.Find("Answer UI").gameObject.SetActive(true);
            //slow down the mouse movement while answering
            player.GetComponent<MouseLook>().sensitivityHor = 0.5f;
            mainCam.GetComponent<MouseLook>().sensitivityVert = 0.5f;
        }

        else{
            //QuitUI
            canvas.transform.Find("Quit UI").gameObject.SetActive(true);
            //pause functionality
            Time.timeScale = 0f;
            mainCam.GetComponent<MouseLook>().enabled = false;
            mainCam.GetComponent<RayShooter>().enabled = false;
            gameObject.GetComponent<FPSInput>().enabled = false;
            gameObject.GetComponent<MouseLook>().enabled = false;
        }

    }


    public void Resume()
    {
        canvas.transform.Find("Answer UI").gameObject.SetActive(false);
        canvas.transform.Find("Quit UI").gameObject.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        mainCam.GetComponent<MouseLook>().enabled = true;
        mainCam.GetComponent<RayShooter>().enabled = true;
        gameObject.GetComponent<FPSInput>().enabled = true;
        gameObject.GetComponent<MouseLook>().enabled = true;
        resumeCalled = false;
        //restore the mouse movement
        player.GetComponent<MouseLook>().sensitivityHor = 5.0f;
        mainCam.GetComponent<MouseLook>().sensitivityVert = 2.0f;
    }
}
