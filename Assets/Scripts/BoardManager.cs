using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {
	public static int columns = 8;
	public static int rows = 8;
	public int wallCount = 5;
	public GameObject[] floorTiles;
	public GameObject[] wallTiles;

	private Transform boardHolder;
	private List<Vector3> gridPositions = new List<Vector3>();

	void InitializeList()
	{
		gridPositions.Clear();

		for(int x = 0; x < columns; x++) {
			for(int y = 0; y < rows; y++) {
				gridPositions.Add(new Vector3(x,y,0f));
			}
		}
	}

	void BoardSetup()
	{
		boardHolder = new GameObject ("Board").transform;

		for(int x = 0; x < columns; x++) {
			for(int y = 0; y < rows; y++) {
				GameObject toInstantiate = floorTiles [Random.Range (0, floorTiles.Length)];
				GameObject instance = Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder);
			}
		}
	}

	Vector3 RandomPosition()
	{
		int randomIndex = Random.Range (0, gridPositions.Count);
		Vector3 randomPosition = gridPositions [randomIndex];
		gridPositions.RemoveAt (randomIndex);
		return randomPosition;
	}

	void PlaceWalls(GameObject[] walls)
	{
		for(int i = 0; i < wallCount; i++)
		{
			Vector3 randomPosition = RandomPosition ();
			GameObject wall = wallTiles [Random.Range (0, wallTiles.Length)];
			Instantiate (wall, randomPosition, Quaternion.identity);
		}
	}

	public void SetUpScene()
	{
		BoardSetup ();
		InitializeList ();
		PlaceWalls (wallTiles);
	}
}
