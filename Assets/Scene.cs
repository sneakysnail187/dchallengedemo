using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{

    public int mDiff = 1;
    public int dDiff = 1;
    public int sDiff = 1;
    public int aDiff = 1;
    public void Start(){

    }
    public void LoadScene(string scene){
        DiffManager.mult = mDiff;
        DiffManager.div = dDiff;
        DiffManager.add = aDiff;
        DiffManager.sub = sDiff;
        SceneManager.LoadScene(scene);
    }
    public void Quit(){
        Application.Quit();
    }
}
