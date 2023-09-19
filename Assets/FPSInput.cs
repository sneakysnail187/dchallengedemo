using UnityEngine;
using System.Collections;

// basic WASD-style movement control
// commented out line demonstrates that transform.Translate instead of charController.Move doesn't have collision detection

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = 9.8f;
    //public float groundDist = 0.4f;
    public LayerMask groundMask;

    private CharacterController _charController;
    //private UIController myUI;
    [SerializeField] private float jumpInterval;
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallingBonus;
    private bool grounded;
    private bool doubleJumped;
    public float dashTime;
    public float dashSpeed;
    public Transform groundCheck;

    private float lastJumpTime = 0f;

    Vector3 velocity;
    Vector3 inputDir;

    void Start() 
    {
        inputDir = new Vector3(0.0f, 0.0f, 0.0f);
        Application.targetFrameRate = 60;
        _charController = GetComponent<CharacterController>();

        grounded = false;
        doubleJumped = false;
    }

    void Update()
    {
        inputDir.x = Input.GetAxis("Horizontal");
        inputDir.z = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.LeftShift)){
            StartCoroutine(dash(inputDir));
        }
        // Ensure on ground
        if (grounded/* && velocity.y < 0*/)
        {
            doubleJumped = false;
            if (Input.GetKeyDown(KeyCode.Space) && Time.time > lastJumpTime + jumpInterval)
            {
                velocity.y = jumpForce;
                lastJumpTime = Time.time;
                grounded = false;
            }
            else if (_charController.velocity.y <= 0)
            {
                velocity.y = -1f;
            }
        }
        else
        {
            velocity.y -= gravity;
            if (_charController.velocity.y < 0)
            {
                velocity.y -= fallingBonus;
            }
            else if(Input.GetKeyDown(KeyCode.Space) && !doubleJumped){
                velocity.y = jumpForce;
                doubleJumped = true;
            }
        }
        velocity.x = Input.GetAxis("Horizontal");
        velocity.z = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        Vector3 movement = (transform.right * velocity.x + transform.forward * velocity.z) * speed;
        movement.y = velocity.y;
        _charController.Move(movement * Time.fixedDeltaTime);

        grounded = Physics.CheckSphere(groundCheck.position, 0.45f, groundMask);
    }

    private IEnumerator dash(Vector3 moveDir){
        float startTime = Time.time;

        while(Time.time < startTime + dashTime){
            _charController.Move(moveDir * dashSpeed *Time.deltaTime);

            yield return null;
        }
    }
}
