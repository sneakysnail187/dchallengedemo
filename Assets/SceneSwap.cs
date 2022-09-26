using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    private float xPos = 0;
    private float ypos = -38.91979f;
    private float zpos = 0;
    private Vector3 tp;
    public GameObject canvas;
    private AsyncOperation sceneAsync;
    private SphereCollider tpBox;
    public string target;

    public int wingNum;
    void Start()
    {
        tpBox = GetComponent<SphereCollider>();
        canvas = GameObject.Find("Canvas");
        if(wingNum == 1){
            xPos = -2.890938f;
            zpos = 146.1741f;
        }
        else if(wingNum == 2){
            xPos = 290.0224f;
            zpos = -21.88322f;
        }
        else if(wingNum == 3){
            xPos = -175.56f;
            zpos = -5.7f;
        }
        else if(wingNum == 4){
            xPos = 14.15857f;
            zpos = -132.387f;
        }
        else{
            xPos = 2.77f;
            ypos = 0;
            zpos = -3;
        }
        tp = new Vector3(xPos,ypos,zpos);

    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            StartCoroutine(LoadLevel(other.transform));
        }
    }

    IEnumerator LoadLevel (Transform playerTrans){
        AsyncOperation scene = SceneManager.LoadSceneAsync(target, LoadSceneMode.Additive);
        scene.allowSceneActivation = false;
        sceneAsync = scene;
        tpBox.enabled = false;
        Time.timeScale = 0f;
        while(scene.progress < 0.9f){
            Debug.Log("Loading scene " + " [][] Progress: " + scene.progress);
            yield return null;
        }
        sceneAsync.allowSceneActivation = true;
        while(!scene.isDone){
            yield return null;
        }
        OnFinishedLoading();
        Time.timeScale = 1f;
        playerTrans.position = tp;
    }

    void enableScene(string scene){
        UnityEngine.SceneManagement.Scene sceneToLoad = SceneManager.GetSceneByName(scene);
        if(sceneToLoad.IsValid()){
            SceneManager.MoveGameObjectToScene(canvas, sceneToLoad);
            SceneManager.SetActiveScene(sceneToLoad);
        }
    }

    void OnFinishedLoading(){
        enableScene(target);
    }
}
