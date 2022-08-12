using UnityEngine;
using System.Collections;

// basic WASD-style movement control
// commented out line demonstrates that transform.Translate instead of charController.Move doesn't have collision detection

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
	public float speed = 6.0f;
	public float gravity = -9.8f;
	public float groundDist = 0.4f;
	public LayerMask groundMask;

	private CharacterController _charController;
	private UIController myUI;
	public float forceconst = 5f;
	private bool canJump;
	public Transform groundCheck;

	Vector3 velocity;
	
	void Start() {
		_charController = GetComponent<CharacterController>();
		myUI = GetComponent<UIController>();
	}
	
	void Update() {
		//transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
		
		canJump = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);
		
		if(canJump && velocity.y < 0){
			velocity.y = -2f;
		}


		float deltaX = Input.GetAxis("Horizontal");
		float deltaZ = Input.GetAxis("Vertical");

		Vector3 movement = transform.right * deltaX + transform.forward * deltaZ;
		
		_charController.Move(movement * speed * Time.deltaTime);

		if(canJump && Input.GetKeyDown(KeyCode.Space)){
			velocity.y = Mathf.Sqrt(forceconst * -2f * gravity);
     	}

		velocity.y += gravity * Time.deltaTime;
		if ((_charController.collisionFlags & CollisionFlags.Above) != 0) {
         if (velocity.y > 0) {
             velocity.y = -velocity.y;
         }
     }

		_charController.Move(velocity * Time.deltaTime);
	}
}
