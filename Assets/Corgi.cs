using UnityEngine;
using System.Collections;

public class Corgi : MonoBehaviour {

	public int health;
	public Room room;

	// Use this for initialization
	void Start () {
		health = 10;
	}

	public void DestroyMe(){
		room.enemies.Remove (gameObject);
		Destroy (gameObject);
	}
}
