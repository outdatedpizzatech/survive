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
		if (Random.value < .5f) {
			if (matrix.CanInsertAtPosition (gridElement.xPosition, gridElement.yPosition + 1)) {
				gridElement.transform.Find ("Doors").Find ("Top").gameObject.SetActive (true);
				InsertNewRoom (gridElement.xPosition, gridElement.yPosition + 1);
			}
		}

		if (Random.value < .5f) {
			if (matrix.CanInsertAtPosition (gridElement.xPosition, gridElement.yPosition - 1)) {
				gridElement.transform.Find ("Doors").Find ("Bottom").gameObject.SetActive (true);
				InsertNewRoom (gridElement.xPosition, gridElement.yPosition - 1);
			}
		}

		if (Random.value < .5f) {
			if (matrix.CanInsertAtPosition (gridElement.xPosition + 1, gridElement.yPosition)) {
				gridElement.transform.Find ("Doors").Find ("Right").gameObject.SetActive (true);
				InsertNewRoom (gridElement.xPosition + 1, gridElement.yPosition);
			}
		}
//
		if (Random.value < .5f) {
			if (matrix.CanInsertAtPosition (gridElement.xPosition - 1, gridElement.yPosition)) {
				gridElement.transform.Find ("Doors").Find ("Left").gameObject.SetActive (true);
				InsertNewRoom (gridElement.xPosition - 1, gridElement.yPosition);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	GameObject InsertNewRoom(int x, int y){
		Vector3 newPosition = matrix.PositionToCoordinate (x, y);

		GameObject panel = Instantiate (Resources.Load ("Panel"), newPosition, Quaternion.identity) as GameObject;

		GetComponent<GFRectGrid>().AlignTransform(panel.transform);

		matrix.matrix[x, y] = panel;
		panel.GetComponent<GridElement>().SetPosition(x, y);

		PopulateNeighbors (panel.GetComponent<GridElement>());

		return(panel);
	}
}
