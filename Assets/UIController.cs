using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	Vector3 initialMapLocation;
	bool mapVisible;
	bool enemiesVisible;
	public static UIController instance;

	// Use this for initialization
	void Start () {
		initialMapLocation = GameObject.Find ("Map").transform.position;
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Reset(){
		enemiesVisible = true;
		RoomController.activeRoom.ShowEnemies ();
	}

	public void ToggleMap(){
		if (mapVisible) {
			GameObject.Find ("Map").transform.position = initialMapLocation;
		} else {
			GameObject.Find ("Map").transform.position = Vector3.zero;
		}
		mapVisible = !mapVisible;
	}

	public void ToggleEnemies(){
		if (enemiesVisible) {
			RoomController.activeRoom.HideEnemies ();
		} else {
			RoomController.activeRoom.ShowEnemies ();
		}
		enemiesVisible = !enemiesVisible;
	}

	public static void HideMap(){
		if (instance.mapVisible) instance.ToggleMap ();
	}
}
