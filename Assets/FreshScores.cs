using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreshScores : MonoBehaviour
{

    //send scores
    public void send(){
        PlayerDataManager.uploadToDatabase();
    }
}
