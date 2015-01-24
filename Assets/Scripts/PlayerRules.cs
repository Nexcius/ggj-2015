using UnityEngine;
using System.Collections;

public class PlayerRules : MonoBehaviour {
	protected const float VOID_HEIGHT = -50.0f;
	GameObject splatter;

	private Vector2 diedPos = Vector2.zero;

	void Start () {
		splatter = transform.FindChild ("PlayerSplatter").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		if(diedPos != Vector2.zero) {
			transform.position = diedPos;
		}

		if (transform.position.y <= VOID_HEIGHT) {
			renderer.enabled = false;
			diedPos = transform.position;
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			Debug.Log ("PLAYER DEATH: ENEMY");
			splatter.SetActive(true);
			renderer.enabled = false;
			diedPos = transform.position;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if(col.tag == "Collectible") {
			Collectible collectibleScript = col.gameObject.GetComponent<Collectible>();
			collectibleScript.Collect();
		}
	}

}
