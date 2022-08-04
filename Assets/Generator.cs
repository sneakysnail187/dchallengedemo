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
            operandOne.text = (Random.Range(1,6)*2).ToString();
            operandTwo.text = (Random.Range(1,6)*2).ToString();
        }
        if(Difficulty == 2){
            operandOne.text = (Random.Range(1,6)*2).ToString();
            operandTwo.text = (Random.Range(1,11)).ToString();
        }
        if(Difficulty == 3){
            operandOne.text = (Random.Range(1,11)).ToString();
            operandTwo.text = (Random.Range(1,11)).ToString();
        }
        if(Difficulty == 4){
            operandOne.text = (Random.Range(1,51)*2).ToString();
            operandTwo.text = (Random.Range(1,51)*2).ToString();
        }
        if(Difficulty == 5){
            operandOne.text = (Random.Range(1,100)).ToString();
            operandTwo.text = (Random.Range(1,51)*2).ToString();
        }
        if(Difficulty == 6){
            operandOne.text = (Random.Range(1,100)).ToString();
            operandTwo.text = (Random.Range(1,100)).ToString();
        }
        if(Difficulty == 7){
            operandOne.text = (Random.Range(1,501)*2).ToString();
            operandTwo.text = (Random.Range(1,501)*2).ToString();
        }
        if(Difficulty == 8){
            operandOne.text = (Random.Range(1,501)*2).ToString();
            operandTwo.text = (Random.Range(1,1000)).ToString();
        }
        if(Difficulty == 9){
            operandOne.text = (Random.Range(1,1000)).ToString();
            operandTwo.text = (Random.Range(1,1000)).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
