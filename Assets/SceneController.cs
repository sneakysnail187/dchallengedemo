using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab = null;
	public List<GameObject> _enemies;
	public List<GameObject> spawnPoints;
	public int enemiesToAdd = 4;
	public bool isMaze;
	GameObject[] doors;

	void Awake() {
		_enemies = new List<GameObject>();
		isMaze = true;
		/*
		doors = GameObject.FindGameObjectsWithTag("Door");
		for(int i = 0; i<doors.Length;i++){
			if(doors[i].GetComponent<ReactiveTarget>().tier == 1){
				doors[i].GetComponent<Generator>().Difficulty = 1;
			}
			else if(doors[i].GetComponent<ReactiveTarget>().operation.text.Equals("-")){
				if(doors[i].GetComponent<ReactiveTarget>().tier < DiffManager.getSub()){
					doors[i].GetComponent<Generator>().Difficulty = 2;
					Debug.Log("dchanges");
				}
				else{
					doors[i].GetComponent<Generator>().Difficulty = DiffManager.getSub();
				}
			}
			else if(doors[i].GetComponent<ReactiveTarget>().operation.text.Equals("+")){
				if(doors[i].GetComponent<ReactiveTarget>().tier < DiffManager.getAdd()){
					doors[i].GetComponent<Generator>().Difficulty = 2;
					Debug.Log("dchangea");
				}
				else{
					doors[i].GetComponent<Generator>().Difficulty = DiffManager.getAdd();
				}
			}
			else if(doors[i].GetComponent<ReactiveTarget>().operation.text.Equals("x")){
				if(doors[i].GetComponent<ReactiveTarget>().tier < DiffManager.getMult()){
					doors[i].GetComponent<Generator>().Difficulty = 2;
					Debug.Log("dchangem");
				}
				else{
					doors[i].GetComponent<Generator>().Difficulty = DiffManager.getMult();
				}
			}
			else{
				if(doors[i].GetComponent<ReactiveTarget>().tier < DiffManager.getDiv()){
					doors[i].GetComponent<Generator>().Difficulty = 2;
					Debug.Log("dchanged");
				}
				else{
					doors[i].GetComponent<Generator>().Difficulty = DiffManager.getDiv();
				}
			}
		}
		*/
	}

	
	public GameObject SpawnEnemy(Vector3 position){
		float angle = Random.Range(0, 360);
		GameObject _enemy = Instantiate(enemyPrefab, position, Quaternion.Euler(0,angle,0)) as GameObject;
		return _enemy;
	}
	void Start() {
			for(int i = 0; i < enemiesToAdd;i++ ){
				if(i < 2){
					_enemies.Add(SpawnEnemy(gameObject.transform.position));	
				}
				else if(i < 5){
					_enemies.Add(SpawnEnemy(spawnPoints.ElementAt(0).transform.position));	
				}
				else if(i < 8){
					_enemies.Add(SpawnEnemy(spawnPoints.ElementAt(1).transform.position));	
				}
				else if(i < 11){
					_enemies.Add(SpawnEnemy(spawnPoints.ElementAt(2).transform.position));	
				}	
				else{
					_enemies.Add(SpawnEnemy(spawnPoints.ElementAt(3).transform.position));	
				}
			}
	}
}
