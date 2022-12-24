using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiffUIController : MonoBehaviour
{
    // this script is attached to the DifficultyPage UI element
    //stores an array of buttons
    public GameObject[] buttons; 

    // Start is called before the first frame update
    void Start()
    {
        //update all easy buttons to indicate easy difficulty by default
        buttons[0].GetComponentInChildren<TMP_Text>().text = "o";
        buttons[3].GetComponentInChildren<TMP_Text>().text = "o";
        buttons[6].GetComponentInChildren<TMP_Text>().text = "o";
        buttons[9].GetComponentInChildren<TMP_Text>().text = "o";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //changes the button at the specified index to indicate a selection
    public void buttonIndicate(int buttonIndex){

        //first we must clear the previous difficulty indication 
        //if the buttonIndex falls within a specific operation range, then clear that range
        if (buttonIndex == 0 || buttonIndex == 1 || buttonIndex == 2){
            //this would mean we are changing in the addition range- so clear all addition
            buttons[0].GetComponentInChildren<TMP_Text>().text = "";
            buttons[1].GetComponentInChildren<TMP_Text>().text = "";
            buttons[2].GetComponentInChildren<TMP_Text>().text = "";
        }
        if (buttonIndex == 3 || buttonIndex == 4 || buttonIndex == 5){
            //this would mean we are changing in the addition range- so clear all addition
            buttons[3].GetComponentInChildren<TMP_Text>().text = "";
            buttons[4].GetComponentInChildren<TMP_Text>().text = "";
            buttons[5].GetComponentInChildren<TMP_Text>().text = "";
        }
        if (buttonIndex == 6 || buttonIndex == 7 || buttonIndex == 8){
            //this would mean we are changing in the addition range- so clear all addition
            buttons[6].GetComponentInChildren<TMP_Text>().text = "";
            buttons[7].GetComponentInChildren<TMP_Text>().text = "";
            buttons[8].GetComponentInChildren<TMP_Text>().text = "";
        }
        if (buttonIndex == 9 || buttonIndex == 10 || buttonIndex == 11){
            //this would mean we are changing in the addition range- so clear all addition
            buttons[9].GetComponentInChildren<TMP_Text>().text = "";
            buttons[10].GetComponentInChildren<TMP_Text>().text = "";
            buttons[11].GetComponentInChildren<TMP_Text>().text = "";
        }
        //set the button's text to a letter "o"
        buttons[buttonIndex].GetComponentInChildren<TMP_Text>().text = "o";
    }
}
