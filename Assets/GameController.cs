﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static bool frozen;
	public static bool inEncounter;
	public static bool gameOver;

	// Use this for initialization
	void Start () {
		gameOver = false;
		Unfreeze ();
	}

	void Update(){
		if (!gameOver && Player.instance.health < 1) {
			EnterGameOver ();
		}
	}

	void EnterGameOver(){
		gameOver = true;
		SpeechBubble.mainBubble.Activate ();
		SpeechBubble.AddMessage ("your adventure has ended.");
		GameObject.Find ("Combat").GetComponent<Canvas>().enabled = false;
		GameObject.Find ("Navigation").GetComponent<Canvas>().enabled = false;
	}
	
	public static void Freeze(){
		frozen = true;
	}

	public static void Unfreeze(){
		frozen = false;
	}


	public static void EnterEncounter(){
		print ("entered encounter");
		inEncounter = true;
		GameObject.Find ("Combat").GetComponent<Canvas>().enabled = true;
		GameObject.Find ("Navigation").GetComponent<Canvas>().enabled = false;
		BattleController.StartBattle ();
	}

	public static void ExitEncounter(){
		inEncounter = false;

		GameObject.Find ("Combat").GetComponent<Canvas>().enabled = false;
		GameObject.Find ("Navigation").GetComponent<Canvas>().enabled = true;
	}
}
