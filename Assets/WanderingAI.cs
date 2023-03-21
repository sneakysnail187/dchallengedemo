using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class WanderingAI : MonoBehaviour {
	public SceneController sc;
	public float speed = 3.0f;
	public float obstacleRange = 4.0f;
	public List<Transform> points;
	int curPoint;
	private Animator anim;
	private bool _alive;
	public bool broken;
	public NavMeshAgent navMeshAgent;
	public float initWaitTime = 4;
	public float initRotate = 2;
	public float viewAng = 90;
	public float viewRad = 15;
	public LayerMask player;
	public LayerMask obstacles;
	public float meshRes = 1f;
	public int edgeIter = 4;
	public float edgeDist = 0.5f;
	public bool left = true;
	private Vector3 minSize = new Vector3(0.5f,0.5f,0.5f);
	Vector3 playLastPos = Vector3.zero;
	Vector3 playerPos;
	float waitTime;
	float rotateTime;
	bool inRange;
	bool near;
	bool patrolling;
	bool seen;
	
	void Start() {
		_alive = true;
		curPoint = 0;
		playerPos = Vector3.zero;
		patrolling = true;
		seen = false;
		inRange = false;

		//patrol points to be removed in favor of random wandering
		points.Add(GameObject.Find("ppoint1").transform);
		points.Add(GameObject.Find("ppoint1 (1)").transform);
		points.Add(GameObject.Find("ppoint1 (2)").transform);
		points.Add(GameObject.Find("ppoint1 (3)").transform);
		points.Add(GameObject.Find("ppoint1 (4)").transform);
		points.Add(GameObject.Find("ppoint1 (5)").transform);
		points.Add(GameObject.Find("ppoint1 (6)").transform);
		points.Add(GameObject.Find("ppoint1 (7)").transform);

		anim = GetComponent<Animator>();
		navMeshAgent = GetComponent<NavMeshAgent>();
		navMeshAgent.isStopped = false;
		navMeshAgent.speed = speed;
		navMeshAgent.SetDestination(points[0].position);
		if(!broken){
			anim.SetBool("Patrol", true);
		}
	}
	
	void Update() {
		if(_alive){
			View(); // continuously check if player is in line of sight
			if(!patrolling){
				chase();
			}
			else{
				patrol();
			}
		}
	}

	private void chase(){
		near = false;
		playLastPos = Vector3.zero;
		if(!seen){ // when seen start sprint anim and adjust speed, set target to player
			anim.SetBool("Spotted", true);
			Move(5.0f);
			navMeshAgent.SetDestination(playerPos);
		}
		if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance){
			if(waitTime <= 0 && !seen && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 6f){
				patrolling = true;
				near = false;
				Move(speed); //when out of range return to patrol behavior
				rotateTime = initRotate;
				waitTime = initWaitTime;
				navMeshAgent.SetDestination(points[curPoint].position);
			}
			else{
				if(Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position)>=2.5f){
					Stop();
					waitTime -= Time.deltaTime;
				}
			}
		}
	}

	private void patrol(){
		if(inRange){ // if player in line of sight range
			if(rotateTime <= 0){
				Move(5.0f); // increase run speed and search based on last known pos of player
				LookingForP(playLastPos);
			}
			else{
				Stop();
				rotateTime -= Time.deltaTime;
			}
		}
		else{ // if player outside of line of sight
			near = false;
			playLastPos = Vector3.zero;
			navMeshAgent.SetDestination(points[curPoint].position); // return to patrol
			if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance){ // when bot in range of target dest
				if(waitTime <= 0){ // when done waiting move to next patrol point (to be removed)
					nextP();
					Move(speed);
					waitTime = initWaitTime;
				}
				else{ // stop while waiting
					Stop();
					waitTime -= Time.deltaTime;
				}
			}
		}
	}

	void Stop(){ // stop mving
		navMeshAgent.isStopped = true;
		navMeshAgent.speed = 0;
	}

	public void nextP(){ //move to next patrol point (to be removed)
		curPoint = Random.Range(0, points.Count -1);
		navMeshAgent.SetDestination(points[curPoint].position);
	}

	void LookingForP(Vector3 player){
		navMeshAgent.SetDestination(player);
		if(Vector3.Distance(transform.position, player) <= 0.3f){
			if(waitTime <=0){
				inRange = false;
				Move(speed);
				navMeshAgent.SetDestination(points[curPoint].position);
				waitTime = initWaitTime;
				rotateTime = initRotate;
			}
			else{
				Stop();
				waitTime -= Time.deltaTime;
			}
		}
	}

	void View(){ // check if player is in line of sight
		Collider[] pInRange = Physics.OverlapSphere(transform.position, viewRad, player);
		for(int i = 0; i < pInRange.Length;i++){
			Transform pPos = pInRange[i].transform;
			Vector3 toPLayer = (pPos.position - transform.position).normalized;
			if(Vector3.Angle(transform.forward, toPLayer) < viewAng/2){ // if player is within range of bots forward view vectors
				float dTP = Vector3.Distance(transform.position, pPos.position);
				if(!Physics.Raycast(transform.position, toPLayer, dTP, obstacles)){ // if there are no obstacles between bot and player set varaibles accordingly
					inRange = true;
					patrolling = false;
				}
				else{ // else not in range
					inRange = false;
				}
			}
			if(Vector3.Distance(transform.position, pPos.position)> viewRad){ // if player outside of max view angle
				inRange = false; // not in range
			}
		
			if(inRange){ // if player spotted set new player position to player current position
				playerPos = pPos.transform.position;
			}
		}
	}

	void Move(float speed){//speed adjuster
		navMeshAgent.isStopped = false;
		navMeshAgent.speed = speed;
	}

	public void SetAlive(bool alive) {
		_alive = alive;
	}

	//death by sword
	public void OnTriggerEnter(Collider other){
		//call the death function
		if(other.CompareTag("sword")){
			//calling the death function on this actor
			death(this.gameObject);
			}
	}

	//shrink to death
	public void Shrink(){
		if(this.gameObject.transform.localScale.x > minSize.x){
			this.gameObject.transform.localScale *= 0.99f;
		}
		else{
			//call the death function
			death(this.gameObject);
		}
	}

	//The AI Death Function
	//This function will be called to handle the death of this AI actor
	public void death(GameObject objectToDelete){
		//Destroy the gameObject that called this function
		Destroy(objectToDelete);
		//Add to the AI death count on the canvas - This is handled by the "PointsAndScoreController" class
		PointsAndScoreController.Instance.incrementEnemyPoints();
	}
}
