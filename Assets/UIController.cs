using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject canvas;
    public static GameObject mainCam;
    public static GameObject player;
    public static bool isPaused = false;
    //Static variable that is set on Update by the AnswerUICollider
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
        //CODE THAT GOVERNS THE ANSWER UI
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

        //CODE THAT GOVERNS THE PAUSE MENU
        if(Input.GetKeyDown("escape")){
            //run the Quit UI
            Pause(true);
        }
    }

    public void Pause(bool isQuit)
    {
        isPaused = true;
        

        if(!isQuit){
            //AnswerUI
            canvas.transform.Find("Answer UI").gameObject.SetActive(true);
            //Activate the input field
            // we also do this when a wrong answer has been put in -so that the field is activated again ( AnswerUICollider.wrongAnswer() )
            canvas.transform.Find("Answer UI").Find("MyInputField").GetComponent<TMP_InputField>().ActivateInputField(); 
            //slow down the mouse movement while answering
            player.GetComponent<MouseLook>().sensitivityHor = 0.5f;
            mainCam.GetComponent<MouseLook>().sensitivityVert = 0.5f;
        }

        else{
            //QuitUI
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
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
        //only remove the Answer UI if the Options menu is not active - that would mean the resume button doesn't remove the AnswerUI
        if(!canvas.transform.Find("Quit UI").gameObject.active){
            //if not active - remove the answerUi because we are not pressing the Options Resume button
            canvas.transform.Find("Answer UI").gameObject.SetActive(false);
        }
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
        //Re-activate the input field
        canvas.transform.Find("Answer UI").Find("MyInputField").GetComponent<TMP_InputField>().ActivateInputField();
    }
}
