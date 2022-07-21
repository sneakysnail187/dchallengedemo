using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    public Transform tpTarget;
    public GameObject player;
    void OnTriggerEnter(Collider other)
    {
        player.transform.position = tpTarget.transform.position;
    }
}
