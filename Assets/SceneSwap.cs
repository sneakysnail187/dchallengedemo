using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    private float xPos = 0;
    private float ypos = -38.91979f;
    private float zpos = 0;
    private Vector3 tp;

    public int wingNum;
    void Start()
    {
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
        else{
            xPos = 14.15857f;
            zpos = -132.387f;
        }
        tp = new Vector3(xPos,ypos,zpos);

    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            StartCoroutine(LoadLevel(other.transform));
        }
    }

    IEnumerator LoadLevel (Transform playerTrans){
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene("Game");
        playerTrans.position = tp;
    }
}
