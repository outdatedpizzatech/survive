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

	void MoveSomewhere(int xOffset, int yOffset){
		Room destination = matrix.RoomAt(xPosition + xOffset, yPosition + yOffset);
		if(destination != null){
			Room origin = matrix.RoomAt (xPosition, yPosition);
			if (origin.DoorAt(xOffset, yOffset) || destination.DoorAt(xOffset * -1, yOffset * -1)) {
				GameObject room = matrix.ElementAtArrayPosition (xPosition + xOffset, yPosition + yOffset);
				transform.position = room.transform.position;
				matrix.grid.AlignTransform (transform);
				xPosition += xOffset;
				yPosition += yOffset;
			}
		}
	}

	public void MoveUp(){
		MoveSomewhere (0, 1);
	}

	public void MoveLeft(){
		MoveSomewhere (-1, 0);
	}

	public void MoveDown(){
		MoveSomewhere (0, -1);
	}

	public void MoveRight(){
		MoveSomewhere (1, 0);
	}
}
