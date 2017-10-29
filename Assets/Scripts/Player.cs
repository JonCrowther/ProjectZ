using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Selector selector;
	public GameObject moveHighlighter;
	public int speed = 2;

	private List<GameObject> movableTiles = new List<GameObject>();

	private void Update() {
		if (Input.GetButtonUp ("Fire1")) {
			transform.position = selector.transform.position;

			for (var i = 0; i < movableTiles.Count; i++) {
				Destroy (movableTiles [i]);
			}

			movableTiles.Clear ();

			for (int x = -speed; x <= speed; x++) {
				for (int y = -speed; y <= speed; y++) {
					if ((Mathf.Abs (x) + Mathf.Abs (y)) <= speed) {
						if ((transform.position.x + x < BoardManager.rows && transform.position.x + x >= 0)
							&& (transform.position.y + y < BoardManager.columns && transform.position.y + y >= 0)) {
							movableTiles.Add(Instantiate (moveHighlighter, new Vector3 (transform.position.x + x, transform.position.y + y, 0f), Quaternion.identity));
						}
					}
				}
			}
		}
	}

	void OnMouseEnter()
	{
		for (var i = 0; i < movableTiles.Count; i++) {
			movableTiles [i].SetActive (true);
		}
	}

	void OnMouseExit()
	{
		for (var i = 0; i < movableTiles.Count; i++) {
			movableTiles [i].SetActive (false);
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		Debug.Log ("Collision Occurred");
	}
}
