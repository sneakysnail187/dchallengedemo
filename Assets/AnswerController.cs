using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerController : MonoBehaviour
{
    public GameObject answerUI;
    public static GameObject mainCam;
    public static bool isPaused = false;


    void Update(){
        if(Input.GetKeyDown("tab")){
            if(isPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void Pause()
    {
        answerUI.SetActive(true);
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
