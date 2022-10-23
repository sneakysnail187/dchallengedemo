using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class WanderingAI : MonoBehaviour {
	public float speed = 3.0f;
	public float obstacleRange = 4.0f;
	public Transform[] points;
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
			View();
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
		if(!seen){
			anim.SetBool("Spotted", true);
			Move(5.0f);
			navMeshAgent.SetDestination(playerPos);
		}
		if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance){
			if(waitTime <= 0 && !seen && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 6f){
				patrolling = true;
				near = false;
				Move(speed);
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
		if(inRange){
			if(rotateTime <= 0){
				Move(5.0f);
				LookingForP(playLastPos);
			}
			else{
				Stop();
				rotateTime -= Time.deltaTime;
			}
		}
		else{
			near = false;
			playLastPos = Vector3.zero;
			navMeshAgent.SetDestination(points[curPoint].position);
			if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance){
				if(waitTime <= 0){
					nextP();
					Move(speed);
					waitTime = initWaitTime;
				}
				else{
					Stop();
					waitTime -= Time.deltaTime;
				}
			}
		}
	}

	void Stop(){
		navMeshAgent.isStopped = true;
		navMeshAgent.speed = 0;
	}

	public void nextP(){
		curPoint = (curPoint +1) %points.Length;
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

	void View(){
		Collider[] pInRange = Physics.OverlapSphere(transform.position, viewRad, player);
		for(int i = 0; i < pInRange.Length;i++){
			Transform pPos = pInRange[i].transform;
			Vector3 toPLayer = (pPos.position - transform.position).normalized;
			if(Vector3.Angle(transform.forward, toPLayer) < viewAng/2){
				float dTP = Vector3.Distance(transform.position, pPos.position);
				if(!Physics.Raycast(transform.position, toPLayer, dTP, obstacles)){
					inRange = true;
					patrolling = false;
				}
				else{
					inRange = false;
				}
			}
			if(Vector3.Distance(transform.position, pPos.position)> viewRad){
				inRange = false;
			}
		
			if(inRange){
				playerPos = pPos.transform.position;
			}
		}
	}

	void Move(float speed){
		navMeshAgent.isStopped = false;
		navMeshAgent.speed = speed;
	}

	public void SetAlive(bool alive) {
		_alive = alive;
	}
}
