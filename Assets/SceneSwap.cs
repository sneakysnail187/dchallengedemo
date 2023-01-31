using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SceneSwap : MonoBehaviour
{
    //reference to animator of the cross fade
    public Animator transitioner;
    //variable to control transition duration
    public float transitionTime = 1f;
    //stores if the object has been overlapped to avoid multiple loading
    public bool hasBeenOverlapped = false;
    //stores a reference to the SoundEffectsManager
    public SoundEffectsManager manager;
    //stores a reference to the AudioManger2 - the researchMusic
    public Audiomanager2 researchMusicManager;
    //stores a reference to the AudioManager3 which contains the script AudioManagerMain
    public AudioManagerMain gameMusicManager;

    public SceneController sc;
    
    private float xPos = 0;
    private float ypos = -38.91979f;
    private float zpos = 0;
    private Vector3 tp;
    public GameObject canvas;
    private AsyncOperation sceneAsync;
    private SphereCollider tpBox;

    //stores the scene that we are going to
    public string target;
    //stores the scene we are leaving from
    public string sceneToDelete;

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
        //target position for this teleporter
        tp = new Vector3(xPos,ypos,zpos);

    }

    void OnTriggerEnter(Collider other){
        if((other.CompareTag("Player") && !hasBeenOverlapped && sc.isMaze) || (other.CompareTag("Player") && !hasBeenOverlapped && sc._enemies.Count <= 0) || (other.gameObject.GetComponent<PlayerCharacter>().hasFailedLevel)){
            sc.isMaze = false;
            hasBeenOverlapped = true;
            //---------------------------------------------------
            //Play the teleportation sound
            manager.play("TeleportAmbience");
            //Animation code begins and everyhting else runs in the background
            //Play animation
            transitioner.SetTrigger("Start");
            //if the teleporters are one of the four, load level
            if (wingNum == 1 || wingNum == 2 || wingNum == 3 || wingNum == 4 || wingNum == 0){
                StartCoroutine(LoadLevel(other.transform));
            }
        }
    }

    IEnumerator LoadLevel (Transform playerTrans){
        //Time.timeScale = 0.5f;
        //wait
        yield return new WaitForSeconds(transitionTime);
        //by this point, the animation of transition has ended (UIPopup) and now alpha is max.
        //we can stop the research music if this object is not null - that means we are in the research hub
        if(researchMusicManager != null){
            researchMusicManager.stop("CommonsUpbeat");
        }
        //else if it is null - that means we are in the game scene and therefore should stop the gameMusicManager
        else{
            //loop to stop all 
            for(int i = 0; i < 3; i++){
                gameMusicManager.stop(gameMusicManager.sounds[i].name);
            }
        }

        //level loading code - BEGIN
        //------------------------------------------------------------------------------------------------------
        //we do not want to laod the ResearchScene
        if(target == "Game"){
            //set the game prompt to active
            //canvas.transform.Find("TaskBorder").gameObject.SetActive(true);
            //prompt the player to get 90 points using PromptController
            GameObject.Find("TaskBorder").GetComponent<PromptController>().promptUI("Get90Points");
            AsyncOperation scene = SceneManager.LoadSceneAsync(target, LoadSceneMode.Additive);
            scene.allowSceneActivation = false;
            sceneAsync = scene;
            //animation begin
            tpBox.enabled = false;
            //time pause - so animation must begin before time pause
            Time.timeScale = 0f;
            while(scene.progress < 0.9f){
                Debug.Log("Loading scene " + " [][] Progress: " + scene.progress);
                yield return null;
            }
            sceneAsync.allowSceneActivation = true;
            while(!scene.isDone){
                yield return null;
            }

        }
        //--------------------------------------------------------------------------------------------------------
        //level loading code - END
        OnFinishedLoading();
        Time.timeScale = 1f;        
        playerTrans.position = tp;
        //unload the Previous scene if it is Game
        if(sceneToDelete == "Game"){
            //set the isMaze attribute to true because we are returning to the maze
            sc.isMaze = true;
            //we are returning to base: IF = they failed
            if(GameObject.Find("Player").GetComponent<PlayerCharacter>().hasFailedLevel){
                //they must quit and try again
                GameObject.Find("TaskBorder").GetComponent<PromptController>().promptUI("TryAgain");
            }
            else{
                //they can unlock doors
                GameObject.Find("TaskBorder").GetComponent<PromptController>().promptUI("UnlockedDoors");
            }
            //
            SceneManager.UnloadSceneAsync(sceneToDelete);
        }
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
        //done loading so end the transition by triggering End
        transitioner.SetTrigger("End");
    }
}
