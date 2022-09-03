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
}
