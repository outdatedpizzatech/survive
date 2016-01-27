﻿using UnityEngine;
using System.Collections;

public class Corgi : MonoBehaviour, IAttackable {

	public int health;
	public Room room;

	// Use this for initialization
	void Start () {
		health = 10;
	}

	public void DestroyMe(){
		room.enemies.Remove (gameObject);
		room.RemoveObject (gameObject);
		Destroy (gameObject);
	}

	public void ReceiveHit(int damage, DamageTypes damageType){
		print ("corgi is hit");
		health -= damage;
	}

	public string Name(){
		return("Corgi-sama");
	}

	public int Health(){
		return(health);
	}

	public void Test(){
		print ("test");
	}

	void OnMouseDown() {
		GameObject.Find ("Combat").GetComponent<Canvas>().enabled = true;
		GameObject.Find ("Combat").transform.Find ("CombatMenu").GetComponent<CombatMenu> ().target = gameObject;
		Transform menuTransform = CombatMenu.instance.transform;
		menuTransform.position = Camera.main.WorldToScreenPoint (transform.position);
	}
}
