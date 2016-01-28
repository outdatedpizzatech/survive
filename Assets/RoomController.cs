using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoomController : MonoBehaviour {

	public RoomController instance;
	public static Room activeRoom;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void ChangeRooms(int xOffset, int yOffset, PlayerMarker playerMarker){
		Room destination = playerMarker.matrix.RoomAt(playerMarker.xPosition + xOffset, playerMarker.yPosition + yOffset);
		if(destination != null){
			Room origin = playerMarker.matrix.RoomAt (playerMarker.xPosition, playerMarker.yPosition);
			if (origin.DoorAt(xOffset, yOffset) || destination.DoorAt(xOffset * -1, yOffset * -1)) {
				GameObject room = playerMarker.matrix.ElementAtArrayPosition (playerMarker.xPosition + xOffset, playerMarker.yPosition + yOffset);
				playerMarker.transform.position = room.transform.position;
				playerMarker.matrix.grid.AlignTransform (playerMarker.transform);
				playerMarker.xPosition += xOffset;
				playerMarker.yPosition += yOffset;
				origin.ExitRoom ();
				destination.EnterRoom ();

				if (destination.messages.Length > 0) {
					SpeechBubble.mainBubble.Activate ();
					SpeechBubble.mainBubble.textToDisplay = destination.messages;
				}

				if (destination.enemies.Count > 0) {
					GameController.EnterEncounter (destination);
				}

				activeRoom = destination;
				UIController.instance.Reset ();
				UpdateNav (destination);
			}
		}
	}

	public static void UpdateNav(Room room){
		GameObject.Find ("Navigation").transform.Find ("MoveUp").GetComponent<Image> ().enabled = room.northDoor;
		GameObject.Find ("Navigation").transform.Find ("MoveLeft").GetComponent<Image> ().enabled = room.westDoor;
		GameObject.Find ("Navigation").transform.Find ("MoveRight").GetComponent<Image> ().enabled = room.eastDoor;
		GameObject.Find ("Navigation").transform.Find ("MoveDown").GetComponent<Image> ().enabled = room.southDoor;
	}
}
