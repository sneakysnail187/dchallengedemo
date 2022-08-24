using UnityEngine;
using System.Collections;
using UnityEngine.UI; /* Required for controlling Canvas UI system */


public class RayShooter : MonoBehaviour {
	private Camera _camera;
	private bool hasSword;
	private Animator anim;
	[SerializeField] private GameObject reticle;

	void Start() {
		_camera = GetComponent<Camera>();
		anim = GetComponentInChildren<Animator>();
		hasSword = true;

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		reticle = GameObject.Find("Reticle");
		reticle.GetComponent<Text>().text = "+";
		reticle.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
		reticle.GetComponent<RectTransform>().position =
            new Vector3(_camera.pixelWidth / 2.0f,
                        _camera.pixelHeight / 2.0f,
                        0.0f);
	}
    

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			if(hasSword){
				anim.SetBool("Attack", true);
			}
			else{
			Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
			Ray ray = _camera.ScreenPointToRay(point);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
				if (target != null) {
					target.ReactToHit();
				} else {
					StartCoroutine(SphereIndicator(hit.point));
				}
			}
			}
			
		}
		else{
			anim.SetBool("Attack", false);
		}
	}

	private IEnumerator SphereIndicator(Vector3 pos) {
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = pos;

		yield return new WaitForSeconds(1);

		Destroy(sphere);
	}
}