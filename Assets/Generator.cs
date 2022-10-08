using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Generator : MonoBehaviour
{
    public int Difficulty;
    void Start()
    {
        Debug.Log(Difficulty);
        if(Difficulty == 1){
            gameObject.GetComponent<ReactiveTarget>().operandOne.text = (Random.Range(1,10)).ToString();
            gameObject.GetComponent<ReactiveTarget>().operandTwo.text = (Random.Range(1,10)).ToString();
        }
        if(Difficulty == 2){
            gameObject.GetComponent<ReactiveTarget>().operandOne.text = (Random.Range(10,100)).ToString();
            gameObject.GetComponent<ReactiveTarget>().operandTwo.text = (Random.Range(10,100)).ToString();
        }
        if(Difficulty == 3){
            gameObject.GetComponent<ReactiveTarget>().operandOne.text = (Random.Range(100,1000)).ToString();
            gameObject.GetComponent<ReactiveTarget>().operandTwo.text = (Random.Range(100,1000)).ToString();
        }
    }
}
