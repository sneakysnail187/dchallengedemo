﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI; /* Required for controlling Canvas UI system */


public class RayShooter : MonoBehaviour {
	private Camera _camera;
	private bool hasSword;
	private bool hasRay;
	private bool hasHack;
	private bool hasFreeze;
	private Animator anim;
	private GameObject reticle;
	private float shrinkRate = 0.5f;
	public GameObject laser;

	void Start() {
		reticle = GameObject.Find("Reticle");
		_camera = GetComponent<Camera>();
		anim = GetComponentInChildren<Animator>();
		hasSword = false;
		hasRay = true;

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		laser.SetActive(false);

		reticle = GameObject.Find("Reticle");
		reticle.GetComponent<Text>().text = "+";
		reticle.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
		reticle.GetComponent<RectTransform>().position =
            new Vector3(_camera.pixelWidth / 2.0f,
                        _camera.pixelHeight / 2.0f,
                        0.0f);
	}
    

	void Update() {
		if (Input.GetMouseButton(0)) {
			if(hasSword){
				//anim.SetBool("Attack", true);
			}
			else{
				if(hasRay){
					laser.SetActive(true);
				}
				Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
				Ray ray = _camera.ScreenPointToRay(point);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit)) {
					GameObject hitObject = hit.transform.gameObject;
					ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
					WanderingAI enemy = hitObject.GetComponent<WanderingAI>();
					if (target != null) {
						target.ReactToHit();
					}
					else if(enemy != null){
						if(hasRay){
							enemy.Shrink();
						}
					}
				}
			}
			
		}
		else{
			//anim.SetBool("Attack", false);
			laser.SetActive(false);
		}
	}

	private IEnumerator SphereIndicator(Vector3 pos) {
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = pos;

		yield return new WaitForSeconds(1);

		Destroy(sphere);
	}
}