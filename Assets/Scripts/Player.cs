using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Selector selector;

	private void Update() {
		if(Input.GetButtonUp("Fire1"))
			transform.position = selector.transform.position;
	}
}
