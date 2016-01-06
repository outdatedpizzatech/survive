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
		if(matrix.HasRoomAt(xPosition, yPosition + 1)){
			GameObject room = matrix.ElementAtArrayPosition(xPosition, yPosition + 1);
			transform.position = room.transform.position;
			matrix.grid.AlignTransform (transform);
			yPosition += 1;
		}
	}

	public void MoveLeft(){
		if(matrix.HasRoomAt(xPosition - 1, yPosition)){
			GameObject room = matrix.ElementAtArrayPosition(xPosition - 1, yPosition);
			transform.position = room.transform.position;
			matrix.grid.AlignTransform (transform);
			xPosition -= 1;
		}
	}

	public void MoveDown(){
		if(matrix.HasRoomAt(xPosition, yPosition - 1)){
			GameObject room = matrix.ElementAtArrayPosition(xPosition, yPosition - 1);
			transform.position = room.transform.position;
			matrix.grid.AlignTransform (transform);
			yPosition -= 1;
		}
	}

	public void MoveRight(){
		if(matrix.HasRoomAt(xPosition + 1, yPosition)){
			GameObject room = matrix.ElementAtArrayPosition(xPosition + 1, yPosition);
			transform.position = room.transform.position;
			matrix.grid.AlignTransform (transform);
			xPosition += 1;
		}
	}
}
