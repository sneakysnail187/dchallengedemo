using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System;

public class AnswerUICollider : MonoBehaviour
{
  //stores the canvas - The canvas is obtained during gameplay
  public GameObject playerAnswer;
  //stores the integers to be tested
  public int firstNumberCheck;
  public int secondNumberCheck;
  //stores the sign to be checked
  public string operatorCheck;
  //stores the input
  public int answerInput;
  //stores the Animator
  Animator openDoorAnim;
  //stores a reference to the door of this collider
  public GameObject doorReference;

  //stores references to the doorUI elements
  public GameObject operand1Door;
  public GameObject operand2Door;
  public GameObject operatorDoor;
  public GameObject warning;

  public bool hasBeenOverlapped = false;
  public bool doorOpen = false;

  void OnTriggerEnter (Collider other){
    //get the canvas
    playerAnswer = GameObject.Find("Canvas");
    //get the Animator to the door of this collider
    openDoorAnim = doorReference.GetComponent<Animator>();

    if(other.GetComponent<Collider>().tag == "Player" && !hasBeenOverlapped && !doorOpen){
        Debug.Log ("AHHHH!!!");
        //Set AnswerTriggerFire of the UI controller to true
        UIController.AnswerTriggerFire = true;
        hasBeenOverlapped = true;
        
    }
  } 

  void OnTriggerStay (Collider other){

    //wait for the player to press the enter key
    //if they press enter
    if(Input.GetKeyDown("return")){
      //get the input answer
      answerInput = int.Parse(playerAnswer.transform.Find("Answer UI").GetChild(0).GetComponent<TMP_InputField>().text);
      //clear the answer
      playerAnswer.transform.Find("Answer UI").GetChild(0).GetComponent<TMP_InputField>().text = "";
      //check wrong or right
      //if answers are same
      if (answerCheck(answerInput)){
        //answer is correct
        correctAnswer(); //run the correct answer code
      }

      else{
        wrongAnswer(); //run the wrong answer code
      }
    }
  } 

  void OnTriggerExit (Collider other){

    if(other.GetComponent<Collider>().tag == "Player" && hasBeenOverlapped){
        Debug.Log ("BYE!!!");
        //Resume(): UIController: remove the Answer UI
        UIController.resumeCalled = true;
        //if the door is still closed: there was no work done
        if(!doorOpen){
          //hasBeenOverlapped back to false
          hasBeenOverlapped = false;
        }
        else{
          //door is Open so we have completed a successful overlap. Work was done! Future overlaps won't trigger the answer UI.
          hasBeenOverlapped = true;
        }
    }
  }

  //method called to have an answer on standby
  public bool answerCheck(int playerGuess){
    //if the sign is addition
    if(operatorCheck == "+"){
      if(playerGuess == (firstNumberCheck+secondNumberCheck)){
        return true;
      }
      else{
        return false;
      }
    }

    //if the sign is minus
    else if(operatorCheck == "-"){
      if(playerGuess == (firstNumberCheck-secondNumberCheck)){
        return true;
      }
      else{
        return false;
      }
    }

    //if the sign is multiplication
    else if(operatorCheck == "x"){
      if(playerGuess == (secondNumberCheck*firstNumberCheck)){
        return true;
      }
      else{
        return false;
      }
    }

    //if the sign is division
    else {
      if(playerGuess == (firstNumberCheck/secondNumberCheck)){
        return true;
      }
      else{
        return false;
      }
    }
  }

  //called for a correct answer
  public void correctAnswer(){

    //destroy the Door UI Elements by setting active to false
    operand1Door.SetActive(false);
    operand2Door.SetActive(false);
    operatorDoor.SetActive(false);
    warning.SetActive(false);

    //remove UI
    //Resume(): UIController: remove the Answer UI
    UIController.resumeCalled = true;
    //open the Door actions
    openDoorAnim.SetBool("openDoor",true);
    //set door open to true
    doorOpen = true;
    }

    //called for a wrong answer
    public void wrongAnswer(){
        
    } 
}
