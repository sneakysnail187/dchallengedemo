using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Services.Authentication;

//This acts as a controller class - test
public class PlayerDataCache : MonoBehaviour
{
    //stores the UI elements that obtain the name
    public GameObject nameInput;
    //stores the UI Elements that obatin the password 
    public GameObject passwordInput;
    //stores a reference to the data manager for this data controller
    public PlayerDataSaver playerDataManager;
    //stores the Player's name
    private string nameCache = "PLAYER";
    //stores the player's Highscore
    private int HighScoreCache = 0; 
    private string playerID = "000001";
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
        Debug.Log(saveData.name + " Cache.SaveData");
        //login
        playerDataManager.SignUpWithUsernamePassword(nameInput.GetComponent<TMP_InputField>().text , passwordInput.GetComponent<TMP_InputField>().text);
        
    }
    //Name Input Update
    public void nameUpdater()
    {
        UpdateName(nameInput.GetComponent<TMP_InputField>().text);
    }
    //Initializer
    public void InitializerButton()
    {
        InitializeData(playerDataManager.loginSaveData);
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
    public string GetID()
    {
        return playerID;
    }

    //Update ID
    public void UpdateID(string playerID)
    {
        this.playerID = playerID;
    }
}
