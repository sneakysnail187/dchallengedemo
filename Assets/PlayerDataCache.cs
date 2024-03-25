using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This acts as a controller class - test
public class PlayerDataCache : MonoBehaviour
{
    //stores a reference to the data manager for this data controller
    public PlayerDataSaver playerDataManager;
    //stores the Player's name
    private string nameCache = "PLAYER";
    //stores the player's Highscore
    private int HighScoreCache = 0; 
    private int playerID = 00001;
    //------------------------------------------
    //INITIALIZE DATA
    public void InitializeData(PlayerDataJson data)
    {
        UpdateName(data.name);
        UpdateScore(data.HighScore);
        UpdateID(data.PlayerID);
    }

    //SAVE DATA
    public void SaveData()
    {
        PlayerDataJson saveData = new PlayerDataJson();
        saveData.name = GetName();
        saveData.HighScore = GetScore();
        saveData.PlayerID = GetID();
        playerDataManager.UpdateSessionData(saveData);
    }

    //------------------------------------------
    //Update Name  
    public void UpdateName(string name)
    {
        this.nameCache = name;
    }
    //Update score
    public void UpdateScore(int score)
    {
        this.HighScoreCache = score;
    }
    //-------------------------------------------

    //Get name
    public string GetName()
    {
        return nameCache;
    }

    //Get HighScore
    public int GetScore()
    {
        return HighScoreCache;
    }
    
    //-----------------------------------------
    public int GetID()
    {
        return playerID;
    }

    //Update ID
    public void UpdateID(int playerID)
    {
        this.playerID = playerID;
    }
}
