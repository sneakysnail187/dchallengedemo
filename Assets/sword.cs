using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    public void onTriggerEnter(Collider other){
		Debug.Log("Lol");
		//call the death function
		if(other.CompareTag("enemy")){
			//calling the death function on this actor
			Destroy(other.gameObject);
			}
	}
}
