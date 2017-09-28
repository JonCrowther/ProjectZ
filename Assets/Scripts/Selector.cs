using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		Vector3	MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //convert to game screen
		MousePosition.x = Mathf.Round(MousePosition.x);
		MousePosition.y = Mathf.Round(MousePosition.y);
		MousePosition.z = 10f;
		transform.position = MousePosition;
	}
}
