using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject answerUI;
    public GameObject quitUI;
    public static GameObject mainCam;
    public static bool isPaused = false;


    void Update(){
        if(Input.GetKeyDown("tab")){
            if(isPaused){
                Resume();
            }
            else{
                Pause(false);
            }
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
        if(!isQuit){
            answerUI.SetActive(true);
        }

        else{
            quitUI.SetActive(true);
        }

        Time.timeScale = 0f;
        isPaused = true;
        gameObject.GetComponent<FPSInput>().enabled = false;
        gameObject.GetComponent<MouseLook>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        mainCam = GameObject.Find("Main Camera");
        mainCam.GetComponent<MouseLook>().enabled = false;
        mainCam.GetComponent<RayShooter>().enabled = false;

    }


    public void Resume()
    {
        answerUI.SetActive(false);
        quitUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        gameObject.GetComponent<FPSInput>().enabled = true;
        gameObject.GetComponent<MouseLook>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        mainCam.GetComponent<MouseLook>().enabled = true;
        mainCam.GetComponent<RayShooter>().enabled = true;
    }
}
