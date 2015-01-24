using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(player.renderer.enabled) {
	        Vector3 newPos = player.transform.position;
	        newPos.z = transform.position.z;

	        transform.position = newPos;
		}
	}
}
