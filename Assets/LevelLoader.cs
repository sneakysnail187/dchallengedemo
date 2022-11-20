using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    //reference to animator of the cross fade
    public Animator transition;

    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {

    }

    //Level loading function
    public void LoadNextLevel(string scene){
        //Audiomanager class has a bool(atStart) that needs to be set to false
        //because we want the sound to fade out.
        Audiomanager1.atStart = false;
        StartCoroutine(LoadLevel(scene));
    }

    //delaying function
    IEnumerator LoadLevel(string sceneName){
        //Play animation
        transition.SetTrigger("Start");

        //wait
        yield return new WaitForSeconds(transitionTime);

        //load next scene
        SceneManager.LoadScene(sceneName);
    }
}
