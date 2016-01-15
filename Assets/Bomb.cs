using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour, IAttackable {

	public int health;
	public Room room;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DestroyMe(){
		Destroy (gameObject);
	}

	public void ReceiveHit(int damage, DamageTypes damageType){
		health -= damage;
	}

	public string Name(){
		return("da bomb");
	}

	public int Health(){
		return(health);
	}


	void OnMouseDown() {
		GameObject.Find ("Combat").GetComponent<Canvas>().enabled = true;
		GameObject.Find ("Combat").transform.Find ("CombatMenu").GetComponent<CombatMenu> ().target = gameObject;
		Transform menuTransform = CombatMenu.instance.transform;
		menuTransform.position = Camera.main.WorldToScreenPoint (transform.position);
	}
}
