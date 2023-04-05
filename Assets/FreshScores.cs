using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreshScores : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //send scores
    public void send(){
        PlayerDataManager.uploadToDatabase();
    }
}
