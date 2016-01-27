using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleController : MonoBehaviour {

	public static BattleController instance;
	public static bool inCombat;
	public Room room;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (!Player.turnAvailable && !GameController.frozen && EventQueue.instance.actionEvents.Count < 1) {
			if (room.enemies.Count < 1) {
				SpeechBubble.mainBubble.Activate ();
				SpeechBubble.AddMessage ("all enemies eliminated", false);
				BattleController.inCombat = false;
				GameController.ExitEncounter ();
			} else {
				foreach (GameObject enemy in room.enemies) {
					enemy.GetComponent<Corgi> ().DoAction ();
				}
			}
			Player.turnAvailable = true;
		}
	}

	public static void StartBattle(Room inputRoom){
		instance.room = inputRoom;
		inCombat = true;
		SpeechBubble.mainBubble.Activate ();
		SpeechBubble.AddMessage ("You encounter some baddies", false);
		Player.turnAvailable = true;
		foreach (GameObject fieldObject in instance.room.fieldObjects) {
			if(fieldObject != Player.instance.gameObject) fieldObject.transform.position = new Vector3 (2, 0, 0);
		}
		foreach (GameObject enemy in instance.room.enemies) {
			enemy.transform.position = Vector3.zero;
		}
	}


}
