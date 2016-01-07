using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int health;
	public int maxHealth = 20;
	public static Player instance;

	// Use this for initialization
	void Start () {
		health = maxHealth;
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
