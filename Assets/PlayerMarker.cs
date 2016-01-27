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
		if(!GameController.frozen){
			RoomController.ChangeRooms (xOffset, yOffset, this);
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
