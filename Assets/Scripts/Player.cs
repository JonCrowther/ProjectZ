using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Selector selector;
	public GameObject moveHighlighter;
	public int speed = 2;

	private void Update() {
		if (Input.GetButtonUp ("Fire1")) {
			transform.position = selector.transform.position;
		}
	}

	void OnMouseEnter()
	{
		for (int x = -speed; x <= speed; x++) {
			for (int y = -speed; y <= speed; y++) {
				if ((Mathf.Abs (x) + Mathf.Abs (y)) <= speed) {
					if((transform.position.x + x < BoardManager.rows && transform.position.x + x >= 0) 
						&& (transform.position.y + y < BoardManager.columns && transform.position.y + y >= 0))
					Instantiate (moveHighlighter, new Vector3 (transform.position.x + x, transform.position.y + y, 0f), Quaternion.identity);
				}
			}
		}
	}

	void OnMouseExit()
	{
		GameObject[] oldHighlights = GameObject.FindGameObjectsWithTag ("Highlight");
		foreach (GameObject highlight in oldHighlights) {
			Destroy (highlight);
		}
	}
}
