using UnityEngine;
using System.Collections;

public class Corgi : MonoBehaviour, IAttackable {

	public int health;
	public Room room;

	// Use this for initialization
	void Start () {
		health = 10;
	}

	public void DestroyMe(){
		SpeechBubble.AddMessage (Name() + " is destroyed", true);
		room.enemies.Remove (gameObject);
		room.RemoveObject (gameObject);
		Destroy (gameObject);
	}

	public void ReceiveHit(int damage, DamageTypes damageType){
		SpeechBubble.AddMessage (Name() + " surstains " + damage + " damage", true);
		health -= damage;

		if (health < 1) {
			IAttackable iAttackable = GetComponent (typeof(IAttackable)) as IAttackable;
			EventQueue.AddDestroy (iAttackable);
		}
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

	public void DoAction(){
		int damage = Random.Range (1, 10);
		Player.instance.health -= damage;
		SpeechBubble.mainBubble.Activate ();
		SpeechBubble.AddMessage (Name() + " bites!", false);
		SpeechBubble.AddMessage ("thy hits decreased by " + damage, false);
	}
}
