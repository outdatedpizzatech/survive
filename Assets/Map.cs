using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

	public int xOrigin;
	public int yOrigin;
	public Matrix matrix;

	// Use this for initialization
	void Start () {
		matrix = GetComponent<Matrix> ();
		xOrigin = Random.Range (0, matrix.xMax);
		yOrigin = Random.Range (0, matrix.yMax);

		GameObject panel = InsertNewRoom (xOrigin, yOrigin);

		GridElement gridElement = panel.GetComponent<GridElement> ();

		gridElement.transform.Find ("Body").GetComponent<SpriteRenderer> ().color = Color.red;

		PopulateNeighbors (gridElement);
	}

	void PopulateNeighbors (GridElement gridElement){
		if(matrix.CanInsertAtPosition(gridElement.xPosition, gridElement.yPosition + 1)){
			InsertNewRoom (gridElement.xPosition, gridElement.yPosition + 1);
		}

		if(matrix.CanInsertAtPosition(gridElement.xPosition, gridElement.yPosition - 1)){
			InsertNewRoom (gridElement.xPosition, gridElement.yPosition - 1);
		}

		if(matrix.CanInsertAtPosition(gridElement.xPosition + 1, gridElement.yPosition)){
			InsertNewRoom (gridElement.xPosition + 1, gridElement.yPosition);
		}
//
		if(matrix.CanInsertAtPosition(gridElement.xPosition - 1, gridElement.yPosition)){
			InsertNewRoom (gridElement.xPosition - 1, gridElement.yPosition);
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
