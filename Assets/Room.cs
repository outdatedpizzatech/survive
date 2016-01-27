using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : MonoBehaviour {
	public bool northDoor;
	public bool southDoor;
	public bool eastDoor;
	public bool westDoor;
	public string[] messages;
	public ArrayList enemies;
	public ArrayList entities;
	public ArrayList fieldObjects;


	// Use this for initialization
	void Start () {
		entities = new ArrayList ();
		enemies = new ArrayList();
		fieldObjects = new ArrayList();
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
			AddEnemy ();

			foreach (GameObject enemy in enemies) {
				enemy.transform.position = GameObject.Find("Bin").transform.position;
			}
		}



		if (randomValue < 1f) {
			AddBomb ();
			AddBomb ();
		}

		randomValue = Random.value;



//		SpeechBubble.mainBubble.textToDisplay = messages;
	}

	void AddBomb(){
		GameObject fieldObject = Instantiate (Resources.Load ("Bomb"), GameObject.Find("Bin").transform.position, Quaternion.identity) as GameObject;
		fieldObject.GetComponent<Bomb> ().room = this;
		entities.Add (fieldObject);
		fieldObjects.Add (fieldObject);
	}

	void AddEnemy(){
		GameObject enemyObject = Instantiate (Resources.Load ("Corgi"), Vector3.zero, Quaternion.identity) as GameObject;
		enemyObject.GetComponent<Corgi> ().room = this;
		enemies.Add (enemyObject);
		entities.Add (enemyObject);
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
		int i = 0;
		foreach (GameObject fieldObject in this.fieldObjects) {
			i++;
			fieldObject.transform.position = new Vector3 (1.1f * i, 1.1f * i, 0);
		}
		i = 0;
		foreach (GameObject enemy in this.enemies) {
			i++;
			enemy.transform.position = new Vector3(-i, -i, 0);
		}
	}

	public void ExitRoom(){
		foreach (GameObject fieldObject in this.entities) {
			fieldObject.transform.position = GameObject.Find("Bin").transform.position;
		}
	}

	public List<GameObject> AllEntities(){
		List<GameObject> list = new List<GameObject> ();

		list.Add (Player.instance.gameObject);
		foreach (GameObject enemy in enemies) {
			list.Add (enemy);
		}
		foreach (GameObject fieldObject in fieldObjects) {
			list.Add (fieldObject);
		}
		return(list);
	}
}
