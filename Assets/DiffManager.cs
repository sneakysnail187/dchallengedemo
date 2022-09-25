using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffManager : MonoBehaviour
{
    public static int mult;
    public static int div;
    public static int add;
    public static int sub;
    public int func = 0;

    public void setter(int diff){
        if(func == 1){
            add = diff;
        }
        else if(func == 2){
            sub = diff;
        }
        else if(func == 3){
            mult = diff;
        }
        else{
            div = diff;
        }
    }
}
