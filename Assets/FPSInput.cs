using UnityEngine;
using System.Collections;

// basic WASD-style movement control
// commented out line demonstrates that transform.Translate instead of charController.Move doesn't have collision detection

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
	public float speed = 6.0f;
	public float gravity = -9.8f;

	private CharacterController _charController;
	private AnswerController AnswerUI;
	public float forceconst = 7f;
	private bool canJump;
	private Rigidbody self;
	
	void Start() {
		_charController = GetComponent<CharacterController>();
		AnswerUI = GetComponent<AnswerController>();
		self = GetComponent<Rigidbody>();
	}
	
	void Update() {
		//transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
		if(canJump){
          	if (Input.GetButtonDown("Jump")){
       			self.AddForce(Vector3.up * forceconst);
       		}
     	}
		
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;
		Vector3 movement = new Vector3(deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude(movement, speed);

		movement.y = gravity;

		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		_charController.Move(movement);
	}
	void OnCollisionEnter(Collision other){
    	if (other.gameObject.tag == "Ground"){
        	canJump = true;
    	}
 	}
	void OnCollisionExit(Collision other)
 	{
    	if (other.gameObject.tag == "Ground"){
        	canJump = false;
     	}
 	}
}
