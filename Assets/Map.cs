using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

	public int xOrigin;
	public int yOrigin;
	public Matrix matrix;
	private GameObject playerMarker;

	// Use this for initialization
	void Start () {
		playerMarker = GameObject.Find ("PlayerMarker");
		matrix = GetComponent<Matrix> ();
		xOrigin = Random.Range (0, matrix.xMax);
		yOrigin = Random.Range (0, matrix.yMax);

		GameObject panel = InsertNewRoom (xOrigin, yOrigin);

		GridElement gridElement = panel.GetComponent<GridElement> ();

		gridElement.transform.Find ("Body").GetComponent<SpriteRenderer> ().color = Color.red;
		playerMarker.transform.position = panel.transform.position;
		playerMarker.GetComponent<PlayerMarker>().matrix = matrix;
		playerMarker.GetComponent<PlayerMarker> ().xPosition = xOrigin;
		playerMarker.GetComponent<PlayerMarker> ().yPosition = yOrigin;
		matrix.grid.AlignTransform (playerMarker.transform);

		PopulateNeighbors (gridElement);
	}

	void PopulateNeighbors (GridElement gridElement){
		bool doorGenerated;

		if (Random.value < .5f) {
			doorGenerated = GenerateDoor (0, 1, "Top", gridElement);
			if (doorGenerated) gridElement.GetComponent<Room> ().northDoor = true;
		}

		if (Random.value < .5f) {
			doorGenerated = GenerateDoor (0, -1, "Bottom", gridElement);
			if (doorGenerated) gridElement.GetComponent<Room> ().southDoor = true;
		}

		if (Random.value < .5f) {
			doorGenerated = GenerateDoor (1, 0, "Right", gridElement);
			if (doorGenerated) gridElement.GetComponent<Room> ().eastDoor = true;
		}

		if (Random.value < .5f) {
			doorGenerated = GenerateDoor (-1, 0, "Left", gridElement);
			if (doorGenerated) gridElement.GetComponent<Room> ().westDoor = true;
		}
	}

	bool GenerateDoor(int xOffset, int yOffset, string doorName, GridElement gridElement){
		if (matrix.CanInsertAtPosition (gridElement.xPosition + xOffset, gridElement.yPosition + yOffset)) {
			gridElement.transform.Find ("Doors").Find (doorName).gameObject.SetActive (true);
			InsertNewRoom (gridElement.xPosition + xOffset, gridElement.yPosition + yOffset);
			return(true);
		}else{
			return(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	GameObject InsertNewRoom(int x, int y){
		Vector3 newPosition = matrix.PositionToCoordinate (x, y);

		GameObject panel = Instantiate (Resources.Load ("Room"), newPosition, Quaternion.identity) as GameObject;

		GetComponent<GFRectGrid>().AlignTransform(panel.transform);

		matrix.matrix[x, y] = panel;
		panel.GetComponent<GridElement>().SetPosition(x, y);

		PopulateNeighbors (panel.GetComponent<GridElement>());

		return(panel);
	}
}
