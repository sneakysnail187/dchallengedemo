using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.CloudSave;
using Unity.Services.Authentication;
using Unity.Services.Core;

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
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //SAVE DATA
    public void UpdateSessionData(PlayerDataJson data)
    {
        sessionSaveData = data;
    }
}
