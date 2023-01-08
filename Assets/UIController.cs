using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

enum UIState { NonPaused, Paused, Answering }

public class UIController : MonoBehaviour
{
    public GameObject canvas;
    public static GameObject mainCam;
    public static GameObject player;
    private static UIState isPaused = UIState.NonPaused;
    public static bool AnswerTriggerFire;
    public static bool resumeCalled;

    [SerializeField] private LayerMask whatIsAnsTrigger;
    
    void Start(){
        player = GameObject.Find("Player");
        canvas = GameObject.Find("Canvas");
        resumeCalled = false;
        AnswerTriggerFire = false;
        mainCam = GameObject.Find("Main Camera");
    }
    void Update(){
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f, whatIsAnsTrigger);
        //exiting the collider
        //if(resumeCalled){
        if(colliders.Length < 1)
        {
            if (isPaused == UIState.Answering)
            {
                Resume();
            }
        }
        //entering the collider
        //if(AnswerTriggerFire){
        else if (colliders[0].GetComponent<AnswerUICollider>().NeedToSetupAnsUI())
        {
            colliders[0].GetComponent<AnswerUICollider>().InAnsAreaCheck();
            if (isPaused != UIState.Paused)
            {
                Pause(false);
                //AnswerTriggerFire = false;
            }
        }
        if (Input.GetKeyDown("escape")){
            if(isPaused == UIState.NonPaused)
            {
                Pause(true);
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause(bool isQuit)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if(!isQuit){
            //AnswerUI
            canvas.transform.Find("Answer UI").gameObject.SetActive(true);
            //Activate the input field
            // we also do this when a wrong answer has been put in -so that the field is activated again ( AnswerUICollider.wrongAnswer() )
            canvas.transform.Find("Answer UI").Find("MyInputField").GetComponent<TMP_InputField>().ActivateInputField(); 
            //slow down the mouse movement while answering
            player.GetComponent<MouseLook>().sensitivityHor = 0.5f;
            mainCam.GetComponent<MouseLook>().sensitivityVert = 0.5f;

            isPaused = UIState.Answering;
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

            isPaused = UIState.Paused;
        }

    }


    public void Resume()
    {
        canvas.transform.Find("Answer UI").gameObject.SetActive(false);
        canvas.transform.Find("Quit UI").gameObject.SetActive(false);
        Time.timeScale = 1f;
        isPaused = UIState.NonPaused;
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
