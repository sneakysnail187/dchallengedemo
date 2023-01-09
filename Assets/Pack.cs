using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pack : MonoBehaviour
{
    [SerializeField] List<GameObject> items = new List<GameObject>();

    public List<GameObject> getItems { get => items; }

    public void AddItem(GameObject itemtoAdd){
        items.Add(itemtoAdd);
    }

    public bool checkIfCollected(int target){
        foreach(GameObject t in items){
            if(target == 1 && t.tag == "sword") return true;

            if(target == 2 && t.tag == "gun") return true;

            if(target == 3 && t.tag == "controller") return true;
        }
        return false;
    }
}
