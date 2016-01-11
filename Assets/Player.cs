using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

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
}
