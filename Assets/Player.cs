using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, IAttackable {

	public int health;
	public int maxHealth;
	public int magic;
	public int maxMagic;
	public static Player instance;

	// Use this for initialization
	void Start () {
		health = maxHealth;
		magic = maxMagic;
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string Name(){
		return("playur");
	}

	void OnMouseDown() {
		GameObject.Find ("Combat").GetComponent<Canvas>().enabled = true;
		GameObject.Find ("Combat").transform.Find ("CombatMenu").GetComponent<CombatMenu> ().target = gameObject;
		Transform menuTransform = CombatMenu.instance.transform;
		menuTransform.position = Camera.main.WorldToScreenPoint (transform.position);
	}

	public void ReceiveHit(int damage, DamageTypes damageType){
		health -= damage;
	}

	public void DestroyMe(){

	}

	public int Health(){
		return(health);
	}
}
