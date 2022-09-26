using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Generator : MonoBehaviour
{
    public int Difficulty;
    public TMP_Text operandOne;
    public TMP_Text operandTwo;
    void Start()
    {
        if(Difficulty == 1){
            operandOne.text = (Random.Range(1,10)).ToString();
            operandTwo.text = (Random.Range(1,10)).ToString();
        }
        if(Difficulty == 2){
            operandOne.text = (Random.Range(1,100)).ToString();
            operandTwo.text = (Random.Range(1,100)).ToString();
        }
        if(Difficulty == 3){
            operandOne.text = (Random.Range(1,1000)).ToString();
            operandTwo.text = (Random.Range(1,1000)).ToString();
        }
    }
}
