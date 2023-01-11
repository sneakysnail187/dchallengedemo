using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerCharacter : MonoBehaviour {
	private int _health;
	[SerializeField]private GameObject healthUI;
	[SerializeField]private GameObject death;
	[SerializeField] Pack backpack = null;
	public GameObject gunUI;
	public GameObject swordUI;
	public GameObject controllerUI;

	void Awake(){
		DontDestroyOnLoad(this.gameObject);
	}
	void Start() {
		_health = 2;
	}

	private void OnTriggerEnter(Collider collision){
		if(collision.CompareTag("gun") || collision.CompareTag("sword") || collision.CompareTag("controller")){
			this.GetComponent<MouseLook>().enabled = false; 
			transform.GetChild(1).GetComponent<MouseLook>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

			if(collision.CompareTag("gun")) gunUI.SetActive(true);

			if(collision.CompareTag("sword")) swordUI.SetActive(true);

			if(collision.CompareTag("controller")) controllerUI.SetActive(true);


			backpack.AddItem(collision.gameObject);
			collision.gameObject.SetActive(false);
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
