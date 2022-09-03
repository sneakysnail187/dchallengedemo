using UnityEngine;
using System.Collections;

public class WanderingAI : MonoBehaviour {
	public float speed = 3.0f;
	public float obstacleRange = 4.0f;
	
	private bool _alive;
	
	void Start() {
		_alive = true;
	}
	
	void Update() {
		if (_alive) {
			transform.Translate(0, 0, speed * Time.deltaTime);
			
			Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;
			if (Physics.SphereCast(ray, 0.75f, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				if (hitObject.GetComponent<PlayerCharacter>()) {
					speed = 5.0f;
				}
				else if (hit.distance < obstacleRange) {
					float angle = Random.Range(-100, 100);
					transform.Rotate(0, angle, 0);
				}
			}
		}
	}

	public void SetAlive(bool alive) {
		_alive = alive;
	}
}
