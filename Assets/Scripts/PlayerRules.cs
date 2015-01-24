using UnityEngine;
using System.Collections;

public class PlayerRules : MonoBehaviour {
	protected const float VOID_HEIGHT = -50.0f;
	GameObject splatter;
	// Use this for initialization
	void Start () {
		splatter = transform.FindChild ("PlayerSplatter").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		if (transform.position.y <= VOID_HEIGHT) {
			// DEATH
			Debug.Log ("DEATH");
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			Debug.Log ("PLAYER DEATH: ENEMY");
			splatter.SetActive(true);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			// TRIGGER ENEMY
		}
	}

}
