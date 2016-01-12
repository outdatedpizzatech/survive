using UnityEngine;
using System.Collections;

public class BattleController : MonoBehaviour {

	public GameObject enemy;
	public static BattleController instance;
	public bool moveFinished = false;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (moveFinished && !GameController.frozen) {
			IAttackable attackable = instance.enemy.GetComponent(typeof(IAttackable)) as IAttackable;
			if (attackable.Health() < 1) {
				SpeechBubble.mainBubble.Activate ();
				SpeechBubble.AddMessage ("thou hast slain " + attackable.Name());
				attackable.DestroyMe ();
				GameController.ExitEncounter ();
			} else {
				int damage = Random.Range (1, 10);
				Player.instance.health -= damage;
				SpeechBubble.mainBubble.Activate ();
				SpeechBubble.AddMessage (attackable.Name() + " bites!");
				SpeechBubble.AddMessage ("thy hits decreased by " + damage);
			}
			moveFinished = false;
		}
	}

	public static void StartBattle(Room room){
		SpeechBubble.mainBubble.Activate ();
		instance.enemy = (GameObject)room.enemies[0];
		IAttackable attackable = instance.enemy.GetComponent(typeof(IAttackable)) as IAttackable;
		SpeechBubble.AddMessage ("You encounter " + attackable.Name());
		instance.moveFinished = false;
		foreach (GameObject enemy in room.enemies) {
			enemy.transform.Find ("Body").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
		}
	}

	public void Attack(){
		if (!moveFinished && !GameController.frozen) {
			SpeechBubble.mainBubble.Activate ();
			int damage = Random.Range (1, 10);
			IAttackable attackable = instance.enemy.GetComponent(typeof(IAttackable)) as IAttackable;

			attackable.ReceiveHit (damage, DamageTypes.Physical);
			SpeechBubble.AddMessage ("you attack!");
			SpeechBubble.AddMessage (attackable.Name() + " sustains " + damage + " damage");
			moveFinished = true;
		}
	}

	public void Heal(){
		if (!moveFinished && !GameController.frozen && Player.instance.magic > 0) {
			Player.instance.magic -= 1;
			SpeechBubble.mainBubble.Activate ();
			int damage = Random.Range (10, 20);
			Player.instance.health += damage;
			SpeechBubble.AddMessage ("you heal for " + damage + "!");
			moveFinished = true;
		}
	}

	public void Fire(){
		if (!moveFinished && !GameController.frozen && Player.instance.magic > 0) {
			Player.instance.magic -= 1;
			SpeechBubble.mainBubble.Activate ();
			int damage = Random.Range (10, 20);
			SpeechBubble.AddMessage ("you cast fire!");
			IAttackable attackable = instance.enemy.GetComponent(typeof(IAttackable)) as IAttackable;

			attackable.ReceiveHit (damage, DamageTypes.Fire);
			SpeechBubble.AddMessage (attackable.Name() + " sustains " + damage + " damage");
			moveFinished = true;
		}
	}

}
