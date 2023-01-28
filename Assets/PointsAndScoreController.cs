using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//class to control all the math related to scores and points.
public class PointsAndScoreController : MonoBehaviour
{
    //a list of variables that store different points related to different points in the game
    public static int enemyPoints;

    // Start is called before the first frame update
    void Start()
    {
        //enemies killed are zero at beginning and updated when the player starts defeating enemies
        enemyPoints = 0;
    }

    //incrementing functions
    public static void incrementEnemyPoints(){
        enemyPoints++;
    }
}
