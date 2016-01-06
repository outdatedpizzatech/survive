using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {
	public bool northDoor;
	public bool southDoor;
	public bool eastDoor;
	public bool westDoor;
	public string[] messages;
	public bool encounter = false;

	// Use this for initialization
	void Start () {
		float randomValue = Random.value;



		if (randomValue < .1f) {
			messages = new string[] { "it sure is creepy in here" };
		} else if (randomValue < .2f) {
			messages = new string[] { "you want to leave!" };
		} else if (randomValue < .6f) {
			messages = new string[] { "don't go there!!!" };
		}else{
			messages = new string[] { "dont die", "or do" };
		}

		if (randomValue < .5f) {
			encounter = true;
		}

		SpeechBubble.mainBubble.textToDisplay = messages;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool DoorAt(int x, int y){
		if (x == 1) {
			return(eastDoor);
		} else if (x == -1) {
			return(westDoor);
		} else if (y == 1) {
			return(northDoor);
		} else if (y == -1) {
			return(southDoor);
		}else{
			return(false);
		}
	}
}
