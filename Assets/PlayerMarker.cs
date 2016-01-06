using UnityEngine;
using System.Collections;

public class PlayerMarker : MonoBehaviour {

	public Matrix matrix;
	public int xPosition;
	public int yPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MoveUp(){
		Room destination = matrix.RoomAt(xPosition, yPosition + 1);
		if(destination != null){
			Room origin = matrix.RoomAt (xPosition, yPosition);
			if (origin.northDoor || destination.southDoor) {
				GameObject room = matrix.ElementAtArrayPosition (xPosition, yPosition + 1);
				transform.position = room.transform.position;
				matrix.grid.AlignTransform (transform);
				yPosition += 1;
			}
		}
	}

	public void MoveLeft(){
		Room destination = matrix.RoomAt(xPosition - 1, yPosition);
		if(destination != null){
			Room origin = matrix.RoomAt (xPosition, yPosition);
			if (origin.westDoor || destination.eastDoor) {
				GameObject room = matrix.ElementAtArrayPosition (xPosition - 1, yPosition);
				transform.position = room.transform.position;
				matrix.grid.AlignTransform (transform);
				xPosition -= 1;
			}
		}
	}

	public void MoveDown(){
		Room destination = matrix.RoomAt (xPosition, yPosition - 1);

		if(destination != null){
			Room origin = matrix.RoomAt (xPosition, yPosition);
			if (origin.southDoor || destination.northDoor) {
				GameObject room = matrix.ElementAtArrayPosition (xPosition, yPosition - 1);
				transform.position = room.transform.position;
				matrix.grid.AlignTransform (transform);
				yPosition -= 1;
			}
		}
	}

	public void MoveRight(){
		Room destination = matrix.RoomAt (xPosition + 1, yPosition);

		if(destination != null){
			Room origin = matrix.RoomAt (xPosition, yPosition);

			if (origin.eastDoor || destination.westDoor) {
				GameObject room = matrix.ElementAtArrayPosition (xPosition + 1, yPosition);
				transform.position = room.transform.position;
				matrix.grid.AlignTransform (transform);
				xPosition += 1;
			}
		}
	}
}
