﻿using UnityEngine;
using System.Collections;

public class BattleController : MonoBehaviour {

	public GameObject enemy;
	public static BattleController instance;
	public static bool inCombat;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (!Player.turnAvailable && !GameController.frozen) {
			IAttackable attackable = instance.enemy.GetComponent(typeof(IAttackable)) as IAttackable;
			if (attackable.Health() < 1) {
				SpeechBubble.mainBubble.Activate ();
				SpeechBubble.AddMessage ("thou hast slain " + attackable.Name(), false);
				attackable.DestroyMe ();
				BattleController.inCombat = false;
				GameController.ExitEncounter ();
			} else {
				int damage = Random.Range (1, 10);
				Player.instance.health -= damage;
				SpeechBubble.mainBubble.Activate ();
				SpeechBubble.AddMessage (attackable.Name() + " bites!", false);
				SpeechBubble.AddMessage ("thy hits decreased by " + damage, false);
			}
			Player.turnAvailable = true;
		}
	}

	public static void StartBattle(Room room){
		inCombat = true;
		SpeechBubble.mainBubble.Activate ();
		instance.enemy = (GameObject)room.enemies[0];
		IAttackable attackable = instance.enemy.GetComponent(typeof(IAttackable)) as IAttackable;
		SpeechBubble.AddMessage ("You encounter " + attackable.Name(), false);
		Player.turnAvailable = true;
		foreach (GameObject fieldObject in room.fieldObjects) {
			if(fieldObject != Player.instance.gameObject) fieldObject.transform.position = new Vector3 (2, 0, 0);
		}
		foreach (GameObject enemy in room.enemies) {
			enemy.transform.position = Vector3.zero;
		}
	}


}
