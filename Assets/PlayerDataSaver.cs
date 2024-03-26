using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.CloudSave;
using Unity.Services.Authentication;
using Unity.Services.Core;
using System.Threading.Tasks;

//This acts as a manager class - test
public class PlayerDataSaver : MonoBehaviour
{
    //stores a data save package file
    public PlayerDataJson loginSaveData;
    public PlayerDataJson sessionSaveData;
    // Start is called before the first frame update
    async void Start()
    {
        await UnityServices.InitializeAsync();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //CLOUD INTERACTIONS
    //Cloud Save - saving the data of the player to the cloud 
    public async void SaveDataToCloud()
    {
        PlayerDataJson data = sessionSaveData;
        string key = data.name;
        string jsonData = JsonUtility.ToJson(data);

        var dataToSave = new Dictionary<string,object>{{key, jsonData}};
        await CloudSaveService.Instance.Data.ForceSaveAsync(dataToSave);
        Debug.Log($"Session data for user '{data.name}' saved to the cloud.");
    }

    //Cloud Retrieval - saving the data of the player to the cloud
    public async void RetrieveDataFromCloud()
    {
        PlayerDataJson data = new PlayerDataJson();
        //stores the json file from the cloud 
        Dictionary<string,string> dataToLoad = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string>{"Jeremiah"});
        Debug.Log($"{sessionSaveData.name}");
        //Obtain the data from the specific key
        string jsonData = dataToLoad["Jeremiah"].ToString();
        //Serialize from json to object
        loginSaveData = JsonUtility.FromJson<PlayerDataJson>(jsonData);
        
    }
    //SAVE DATA
    public void InitializeLoginData(PlayerDataJson data)
    {
        loginSaveData = data;
    }
    public void UpdateSessionData(PlayerDataJson data)
    {
        sessionSaveData = data;
    }

    //Signup with Username
    public async Task SignUpWithUsernamePassword(string username, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(username, password);
            Debug.Log("SignUp is successful.");
        }
        catch (AuthenticationException ex)
        {
            // Compare error code to AuthenticationErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
            SignInWithUsernamePassword(username, password);
        }
        catch (RequestFailedException ex)
        {
            // Compare error code to CommonErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
    }
    
    //SignIn With Username
    public async Task SignInWithUsernamePassword(string username, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(username, password);
            Debug.Log("SignIn is successful.");
        }
        catch (AuthenticationException ex)
        {
            // Compare error code to AuthenticationErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex)
        {
            // Compare error code to CommonErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
    }
    
    //Adding a user to an anonymous 
    public async Task AddUsernamePasswordAsync(string username, string password)
    {
        try
        {
            await AuthenticationService.Instance.AddUsernamePasswordAsync(username, password);
            Debug.Log("Username and password added.");
        }
        catch (AuthenticationException ex)
        {
            // Compare error code to AuthenticationErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex)
        {
            // Compare error code to CommonErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
    }
}
