using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject canvas;
    public static GameObject mainCam;
    public static bool isPaused = false;
    void Start(){
        canvas = GameObject.Find("Canvas");
    }
    void Update(){
        if(Input.GetKeyDown("tab")){
            if(!isPaused){
                Pause(false);
            }
        }
        if(Input.GetKeyDown("return") && isPaused){
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
        if(!isQuit){
            canvas.transform.Find("Answer UI").gameObject.SetActive(true);
        }

        else{
            canvas.transform.Find("Quit UI").gameObject.SetActive(true);
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
        canvas.transform.Find("Answer UI").gameObject.SetActive(false);
        canvas.transform.Find("Quit UI").gameObject.SetActive(false);
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
