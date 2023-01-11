using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab = null;
	public List<GameObject> _enemies;
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

	
	public GameObject SpawnEnemy(){
		GameObject _enemy = Instantiate(enemyPrefab, transform) as GameObject;
		float angle = Random.Range(0, 360);
		_enemy.transform.Rotate(0, angle, 0);
		return _enemy;
	}
	void Start() {

			for(int i = 0; i < enemiesToAdd;i++ ){
				_enemies.Add(SpawnEnemy());			
			}
	}
}
