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

	public void ReceiveHit(int damage, DamageTypes damageType){
		health -= damage;
	}
}
