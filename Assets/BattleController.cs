using UnityEngine;
using System.Collections;

public class BattleController : MonoBehaviour {

	public GameObject enemy;
	public static BattleController instance;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void StartBattle(){
		instance.enemy = Instantiate (Resources.Load ("Corgi"), Vector3.zero, Quaternion.identity) as GameObject;
		SpeechBubble.AddMessage ("You encounter a corgi!");
	}

	public void Attack(){
		if (!GameController.frozen) {
			Destroy (enemy);
			SpeechBubble.mainBubble.Activate ();
			SpeechBubble.AddMessage ("u win");
			GameController.ExitEncounter ();
		}
	}

}
