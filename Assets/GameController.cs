using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static bool frozen;
	public static bool inEncounter;

	// Use this for initialization
	void Start () {
		Unfreeze ();
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
