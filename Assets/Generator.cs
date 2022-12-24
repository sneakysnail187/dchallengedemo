using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Generator : MonoBehaviour
{
    //reference to this door's box collider
    public GameObject theCollider;
    //stores the corresponding difficulties for the operations
    public int addition_Difficulty;
    public int minus_Difficulty;
    public int multiply_Difficulty;
    public int divide_Difficulty;
    //stores the two integers to be used in the operation and the corresponding UI TMP texts
    public int firstNumber;
    public int secondNumber;
    public TMP_Text operandOne;
	public TMP_Text operandTwo;
    //stores a string representation of the operand: either +, -, ÷, x
    public TMP_Text operation;
    public string operatorSign;
    //stores the ranges for the different number generators and changes based on difficulty
    //public int addRangeMin;
    //public int addRangeMax;
    //public int minusRangeMin;
    //public int minusRangeMax;
    //public int timesRangeMin;
    //public int timesRangeMax;
    //public int divideRangeMin;
    //public int divideRangeMax;

    void Start()
    {

        //get the operator
        operatorSign = operation.text;
        //get the respective difficulties
        addition_Difficulty = DiffManager.getAdd();
        minus_Difficulty = DiffManager.getSub();
        multiply_Difficulty = DiffManager.getMult();
        divide_Difficulty = DiffManager.getDiv();
        //run the range Setter for this object

        //rangeSetter(Difficulty);
        /*
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
        */

        //DIVISION
        //Case 1: Generating Numbers for Division
        //variables r1, r2 and k(for even integer division)
        if(operatorSign == "÷"){
            //k ensures that there is an integer answer
            int r1 = Random.Range(1,10);
            int k = Random.Range(1,5);
            int r2 = r1 * k;
            firstNumber = r2;
            secondNumber = r1;
        }

        //SUBTRACTION
        //Case 2: Generating Numbers for Minus
        //variables r1, r2 and k(for non-negative answers)
        if(operatorSign == "-"){
            //k ensures that there is a positive answer
            int s1 =0;
            int s2 =0;
            if(minus_Difficulty == 1){
                int n = Random.Range(2,4);
                for(int i = 0; i<n;i++){
                    int r1 = Random.Range(0,10);
                    int r2 = Random.Range(0,r1);
                    r1 *= 10^i;
                    r2 *= 10^i;
                    s1+=r1;
                    s2+=r2;
                }
            }
            if(minus_Difficulty == 2){
                s1 = Random.Range(0, 10000);
                int k = Random.Range(0, 10000);
                s2 = k+s1;
            }
            if(minus_Difficulty == 3){
                s1 = Random.Range(100000,1000000);
                int k = Random.Range(100000,1000000);
                s2 = s1 + k;
            }
            firstNumber = s1;
            secondNumber = s2;
        }

        //ADDITION
        //Case 3: Generating Numbers for Add
        //variables r1, r2 
        if(operatorSign == "+"){
            int s1 =0;
            int s2 =0;
            if(addition_Difficulty == 1){
                int n = Random.Range(2,4);
                for(int i = 0; i<n;i++){
                    int r1 = Random.Range(0,10);
                    int k = 9-r1;
                    int r2;
                    if (k == 0){
                        r2 = 0;
                    }
                    else{
                        r2 = Random.Range(0,(k+1));
                    }
                    r1 = r1 * 10^i;
                    r2 = r2 * 10^i;
                    s1=s1+r1;
                    s2=s2+r2;
                }
            }
            if(addition_Difficulty == 2){
                s1 = Random.Range(1000, 100000);
                s2 = Random.Range(1000, 100000);
            }
            if(addition_Difficulty == 3){
                s1 = Random.Range(100000,10000000);
                s2 = Random.Range(100000,10000000);
            }

            firstNumber = s1;
            secondNumber = s2;
        }

        //Case 4: Generating Numbers for times
        //variables r1, r2 
        if(operatorSign == "x"){
            int r1 = Random.Range(0,13);
            int r2 = Random.Range(0,13);
            firstNumber = r1;
            secondNumber = r2;
        }

        //set the Operands accordingly
        operandOne.text = firstNumber.ToString();
        operandTwo.text = secondNumber.ToString();
        //send them to the collider
        theCollider.GetComponent<AnswerUICollider>().firstNumberCheck =firstNumber;
        theCollider.GetComponent<AnswerUICollider>().secondNumberCheck =secondNumber;
        //send the operator sign to the collider
        theCollider.GetComponent<AnswerUICollider>().operatorCheck = operatorSign;

    }

    /*
    public void rangeSetter(int difficulty) {
        //Difficulty 1
        if(difficulty == 1){
            divideRangeMin = 1;
            divideRangeMax = 10;
            minusRangeMin = 1;
            minusRangeMax = 10;
            addRangeMin = 1;
            addRangeMax = 10;
            timesRangeMin = 0;
            timesRangeMax = 10;
        }
        //Difficulty 2
        if(difficulty == 2){
            divideRangeMin = 1;
            divideRangeMax = 12;
            minusRangeMin = 1;
            minusRangeMax = 100;
            addRangeMin = 1;
            addRangeMax = 100;
            timesRangeMin = 7;
            timesRangeMax = 12;
        }
        //Difficulty 3
        if(difficulty == 3){
            divideRangeMin = 1;
            divideRangeMax = 20;
            minusRangeMin = 1;
            minusRangeMax = 1000;
            addRangeMin = 1;
            addRangeMax = 1000;
            timesRangeMin = 0;
            timesRangeMax = 50;
        }
    }
    */
}
