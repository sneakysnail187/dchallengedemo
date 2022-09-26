using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab = null;
	private List<GameObject> _enemies = new List<GameObject>(); 
	public int enemiesToAdd = 0;
	GameObject[] doors;

	void Awake() {
		doors = (GameObject[]) GameObject.FindObjectsOfType(typeof(Generator));
		for(int i = 0; i<doors.Length;i++){
			if(doors[i].GetComponent<ReactiveTarget>().tier == 1){
				doors[i].GetComponent<Generator>().Difficulty = 1;
			}
			else if(doors[i].transform.position.x > 275){
				if(doors[i].GetComponent<ReactiveTarget>().tier < DiffManager.sub){
					doors[i].GetComponent<Generator>().Difficulty = 2;
				}
				else{
					doors[i].GetComponent<Generator>().Difficulty = DiffManager.sub;
				}
			}
			else if(doors[i].transform.position.z > 130){
				if(doors[i].GetComponent<ReactiveTarget>().tier < DiffManager.add){
					doors[i].GetComponent<Generator>().Difficulty = 2;
				}
				else{
					doors[i].GetComponent<Generator>().Difficulty = DiffManager.add;
				}
			}
			else if(doors[i].transform.position.x < -160){
				if(doors[i].GetComponent<ReactiveTarget>().tier < DiffManager.mult){
					doors[i].GetComponent<Generator>().Difficulty = 2;
				}
				else{
					doors[i].GetComponent<Generator>().Difficulty = DiffManager.mult;
				}
			}
			else{
				if(doors[i].GetComponent<ReactiveTarget>().tier < DiffManager.div){
					doors[i].GetComponent<Generator>().Difficulty = 2;
				}
				else{
					doors[i].GetComponent<Generator>().Difficulty = DiffManager.div;
				}
			}
		}
	}
	public GameObject SpawnEnemy(){
		GameObject _enemy = Instantiate(enemyPrefab) as GameObject;
		_enemy.transform.position = new Vector3(0, 1, 0);
		float angle = Random.Range(0, 360);
		_enemy.transform.Rotate(0, angle, 0);
		return _enemy;
	}
	void Update() {
		List<GameObject> current = _enemies;
		for(int i = 0; i < current.Count;i++ ){
			GameObject _enemy = current[i];
			if (_enemy == null) {
				_enemies[i] = SpawnEnemy();
				for(int x = 0; x < enemiesToAdd; x++){
					_enemies.Add(SpawnEnemy());
				}
			}
		}
	}
}
