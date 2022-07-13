using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {

	public bool isDead;
	public float deathAnimLength = 1.0f;
	public float deathAngle = 30.0f;
	private bool startAnim = false;
	private float currentDeathTimer = 0.0f;
	private float angleCovered = 0.0f;
	[SerializeField] private GameObject tombstonePrefab = null;

	void Update(){
		if(startAnim){
			startAnim = false;
			currentDeathTimer = deathAnimLength;
		}

		if(currentDeathTimer > 0){
			currentDeathTimer = currentDeathTimer - Time.deltaTime;
			float angleToRotate = Time.deltaTime * deathAngle;
			float angleleft = deathAngle - angleCovered;

			if(angleleft < angleToRotate){
				angleToRotate = angleleft;
				currentDeathTimer = -1;
			}
			angleCovered += angleToRotate;
			transform.Translate(0,angleToRotate,0);
		}
	}

	public void ReactToHit() {
		startAnim = true;
		StartCoroutine(Die());
	}

	private IEnumerator Die() {
		isDead = true;
		yield return new WaitForSeconds(1.5f);
		Destroy(this.gameObject);
	}
}
