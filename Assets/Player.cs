using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int health;
	public static Player instance;

	// Use this for initialization
	void Start () {
		health = 100;
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
