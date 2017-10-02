using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public float speed = 1.0f;

	// LateUpdate is called once per frame, after everything else has moved
	// Keeps the camera from being jittery
	void LateUpdate () {
		float vertical = Input.GetAxisRaw ("Vertical");
		float horizontal = Input.GetAxisRaw ("Horizontal");
		Vector3 cameraPosition = new Vector3 (horizontal, vertical, -10f);
		
		transform.position += cameraPosition * speed * Time.deltaTime;
	}
}
