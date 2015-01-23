using UnityEngine;
using System.Collections;

public class Retricle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 mousePos = Input.mousePosition;
		if (Input.mousePosition != null) {
			Vector2 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			transform.position = pos;
		} 	
	}

	void OnGUI() {

	}
}
