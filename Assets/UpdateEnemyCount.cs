using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateEnemyCount : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //update the UI element to the current score
        this.gameObject.GetComponent<TMP_Text>().text = PointsAndScoreController.enemyPoints.ToString();
    }
}
