using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerDataManager : object
{
    //stores the different player fields, name, score
    private static string name = "PLAYER";
    private static int score;

    //methods for updating and returning the fields
    public static void UpdateName(string nameInput){
        //update the name
        name = nameInput;
    }

    //methods for updating and returning the fields
    public static void UpdateScore(int scoreInput){
        //update the name
        score = scoreInput;
    }

    //methods for updating and returning the fields
    public static string getName(){
        //return the name
        return name;
    }

    //methods for updating and returning the fields
    public static int getScore(){
        //return the score
        return score;
    }

    public static void uploadToDatabase(){
        HighScores.UploadScore(name, score);
    }
}
