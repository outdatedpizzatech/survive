using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour, IAttackable {

	public int health = 1;
	public Room room;
	public GameObject spawnPoint;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DestroyMe(){
		room.RemoveObject (gameObject);
		Destroy (gameObject);
	}

	public void ReceiveHit(int damage, DamageTypes damageType){
		health -= damage;
		int index = EventQueue.AddMessage ("the bomb receives damage");
		if(damageType == DamageTypes.Fire){
			Explode (index);
		}
	}

	void Explode(int index){
		index = EventQueue.AddMessage ("the bomb explodes!", index + 1);
		EventQueue.AddDestroy (gameObject, index + 1);
		foreach(GameObject item in room.AllEntities()){
			if (item != gameObject) {
				EventQueue.AddEvent (item, 20, DamageTypes.Fire);
			}
		}

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
