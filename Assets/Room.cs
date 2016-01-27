using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {
	public bool northDoor;
	public bool southDoor;
	public bool eastDoor;
	public bool westDoor;
	public string[] messages;
	public ArrayList enemies;
	public ArrayList fieldObjects;


	// Use this for initialization
	void Start () {
		fieldObjects = new ArrayList ();
		enemies = new ArrayList();
		float randomValue = Random.value;

//		if (randomValue < .1f) {
//			messages = new string[] { "it sure is creepy in here" };
//		} else if (randomValue < .2f) {
//			messages = new string[] { "you want to leave!" };
//		} else if (randomValue < .6f) {
//			messages = new string[] { "don't go there!!!" };
//		}else{
//			messages = new string[] { "dont die", "or do" };
//		}

		if (randomValue < .5f) {
			AddEnemy ();
//			AddEnemy ();

			foreach (GameObject enemy in enemies) {
				enemy.transform.position = GameObject.Find("Bin").transform.position;
			}
		}



		if (randomValue < .8f) {
			GameObject fieldObject = Instantiate (Resources.Load ("Bomb"), GameObject.Find("Bin").transform.position, Quaternion.identity) as GameObject;
			fieldObject.GetComponent<Bomb> ().room = this;
			fieldObjects.Add (fieldObject);
		}

		randomValue = Random.value;



//		SpeechBubble.mainBubble.textToDisplay = messages;
	}

	void AddEnemy(){
		GameObject enemyObject = Instantiate (Resources.Load ("Corgi"), Vector3.zero, Quaternion.identity) as GameObject;
		enemyObject.GetComponent<Corgi> ().room = this;
		enemies.Add (enemyObject);
		fieldObjects.Add (enemyObject);
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

	public void RemoveObject(GameObject fieldObject){
		fieldObjects.Remove (fieldObject);
	}

	public void AddObject(GameObject fieldObject){
		fieldObjects.Add (fieldObject);
	}

	public void EnterRoom(){
		this.AddObject (Player.instance.gameObject);
		foreach (GameObject fieldObject in this.fieldObjects) {
			if(fieldObject != Player.instance.gameObject) fieldObject.transform.position = new Vector3 (2, 0, 0);
		}
		foreach (GameObject enemy in this.enemies) {
			enemy.transform.position = Vector3.zero;
		}


	}

	public void ExitRoom(){
		this.RemoveObject (Player.instance.gameObject);
		foreach (GameObject fieldObject in this.fieldObjects) {
			if(fieldObject != Player.instance.gameObject) fieldObject.transform.position = GameObject.Find("Bin").transform.position;
		}
	}
}
