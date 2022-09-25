using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab = null;
	private List<GameObject> _enemies = new List<GameObject>(); 
	public int enemiesToAdd = 0;
	Generator[] doors;

	private void Awake() {
		doors = (Generator[]) GameObject.FindObjectsOfType(typeof(Generator));
		for(int i = 0; i<doors.Length;i++){
			if(doors[i].transform.position.x > 275){
				doors[i].GetComponent<Generator>().Difficulty = DiffManager.sub;
			}
			else if(doors[i].transform.position.z > 130){
				doors[i].GetComponent<Generator>().Difficulty = DiffManager.add;
			}
			else if(doors[i].transform.position.x < 160){
				doors[i].GetComponent<Generator>().Difficulty = DiffManager.mult;
			}
			else{
				doors[i].GetComponent<Generator>().Difficulty = DiffManager.div;
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
