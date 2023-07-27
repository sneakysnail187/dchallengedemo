using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerDataManager : object
{
    //stores the different player fields, name, score
    private static string name = "PLAYER";
    private static int score;
    private static float time = 0.0f;

    //methods for updating and returning the fields
    public static void UpdateTime(float timeSegment){
        //increment total time
        time += timeSegment;
    }
    public static void UpdateName(string nameInput){
        //update the name
        name = nameInput;
    }

    public static void UpdateScore(int scoreInput){
        //update the name
        score = scoreInput;
    }

    public static float getTime(){
        return time;
    }

    public static string getName(){
        //return the name
        return name;
    }

    public static int getScore(){
        //return the score
        return score;
    }

    public static void uploadToDatabase(){
        HighScores.UploadScore(name, score);
    }
}
