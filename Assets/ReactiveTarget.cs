using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class ReactiveTarget : MonoBehaviour {

	public bool isDead;
	public float deathAnimLength = 1.0f;
	public float deathAngle = 30.0f;
	private bool startAnim = false;
	private float currentDeathTimer = 0.0f;
	private float angleCovered = 0.0f;
	public TMP_Text operandOne;
	public TMP_Text operandTwo;
	public TMP_Text operation;
	public TMP_InputField answer;
	int parseOne;
	int parseTwo;
	int answerParse;


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
		
		parseOne = int.Parse(operandOne.text);
		parseTwo = int.Parse(operandTwo.text);
		answerParse = int.Parse(answer.text);
		
		if(operation.text == "x"){
			if(parseOne * parseTwo == answerParse){
				startAnim = true;
				StartCoroutine(Die());
			}
		}
		else if(operation.text == "÷"){
			if(parseOne / parseTwo == answerParse){
				startAnim = true;
				StartCoroutine(Die());
			}
		}
		else if(operation.text == "-"){
			if(parseOne - parseTwo == answerParse){
				startAnim = true;
				StartCoroutine(Die());
			}
		}
		else if(operation.text == "+"){
			if(parseOne + parseTwo == answerParse){
				startAnim = true;
				StartCoroutine(Die());
			}
		}
		
	}

	private IEnumerator Die() {
		isDead = true;
		yield return new WaitForSeconds(1.5f);
		Destroy(this.gameObject);
	}
}
