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
			if (instance.enemy.GetComponent<Corgi> ().health < 1) {
				SpeechBubble.mainBubble.Activate ();
				SpeechBubble.AddMessage ("thou hast slain the corgi");
				instance.enemy.GetComponent<Corgi> ().DestroyMe ();
				GameController.ExitEncounter ();
			} else {
				int damage = Random.Range (1, 10);
				Player.instance.health -= damage;
				SpeechBubble.mainBubble.Activate ();
				SpeechBubble.AddMessage ("the corgi bites!");
				SpeechBubble.AddMessage ("thy hits decreased by " + damage);
			}
			moveFinished = false;
		}
	}

	public static void StartBattle(Room room){
		SpeechBubble.mainBubble.Activate ();
		instance.enemy = (GameObject)room.enemies[0];
		SpeechBubble.AddMessage ("You encounter a corgi!");
		instance.moveFinished = false;
		foreach (GameObject enemy in room.enemies) {
			enemy.transform.Find ("Body").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
		}
	}

	public void Attack(){
		if (!moveFinished && !GameController.frozen) {
			SpeechBubble.mainBubble.Activate ();
			int damage = Random.Range (1, 10);
			instance.enemy.GetComponent<Corgi> ().health -= damage;
			SpeechBubble.AddMessage ("you attack!");
			SpeechBubble.AddMessage ("corgi sustains " + damage + " damage");
			moveFinished = true;
		}
	}

}
