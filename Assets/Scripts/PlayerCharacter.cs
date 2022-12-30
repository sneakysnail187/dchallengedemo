using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerCharacter : MonoBehaviour {
	private int _health;
	[SerializeField]private GameObject healthUI;
	[SerializeField]private GameObject death;
	[SerializeField] Pack backpack = null;

	void Awake(){
		DontDestroyOnLoad(this.gameObject);
	}
	void Start() {
		_health = 2;
	}

	private void OnTriggerEnter(Collider collision){
		if(collision.CompareTag("Item")){
			backpack.AddItem(collision.gameObject);
			Destroy(collision.gameObject);
		}
	}

	public void Hurt(int damage) {
		_health -= damage;
		var textComp = healthUI.GetComponent<Text>();
		string hp = "";
		for(int i = 0; i<_health;i++){
			hp = hp + "*";
		}
		if(_health > 0){
			textComp.text = "Health: " + _health + " " + hp;
		}
		else{
			textComp.text = "Health: " + _health + " " + hp;
			death.SetActive(true);
		}
		Debug.Log("Health: " + _health);
	}
}
