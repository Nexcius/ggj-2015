using UnityEngine;
using System.Collections;

public class PlayerRules : MonoBehaviour {
	protected const float VOID_HEIGHT = -50.0f;
	GameObject splatter;

	private Vector2 diedPos = Vector2.zero;

	[SerializeField]
	protected GameObject timeTravelDevice;

	private float changeSceneTime = 3.0f;
	private string sceneChance = "";



	void Start () {
		splatter = transform.FindChild ("PlayerSplatter").gameObject;
		changeSceneTime = 3.0f;
		sceneChance = "";
	}
	
	// Update is called once per frame
	void Update () {
		if(diedPos != Vector2.zero) {
			transform.position = diedPos;
		}

		if(sceneChance.Length > 0) {
			if(sceneChance == "WinScreen") {
				transform.position = timeTravelDevice.transform.position + new Vector3(2.0f, 1.0f, 0.0f);

				for(int i = 0; i < transform.childCount; i++) {
					transform.GetChild(i).gameObject.SetActive(false);
				}
			}

			renderer.enabled = false;

			GameObject go = GameObject.Find("Retricle");
			if(go != null) {
				go.SetActive(false);
			}

			if(changeSceneTime <= 0.0f) {
				Application.LoadLevel (sceneChance);
			} else {
				changeSceneTime -= Time.deltaTime;
			}
		}
	}

	void FixedUpdate() {
		if (transform.position.y <= VOID_HEIGHT) {
			renderer.enabled = false;
			diedPos = transform.position;
			sceneChance = "LossScreen";
		}

		for(int childId = 0; childId < timeTravelDevice.transform.childCount; childId++) {
			if(!timeTravelDevice.transform.GetChild(childId).gameObject.activeSelf) {
				return;
			}
		}
		sceneChance = "WinScreen";
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			Debug.Log ("PLAYER DEATH: ENEMY");
			splatter.SetActive(true);
			renderer.enabled = false;
			diedPos = transform.position;

			sceneChance = "LossScreen"; // Prepare loss scene
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if(col.tag == "Collectible") {
			Collectible collectibleScript = col.gameObject.GetComponent<Collectible>();
			collectibleScript.Collect();
		}
		else if(col.tag == "Spike") {
			Debug.Log ("PLAYER DEATH: SPIKE");
			splatter.SetActive(true);
			renderer.enabled = false;
			diedPos = transform.position;

			sceneChance = "LossScreen"; // Prepare loss scene
		}
	}

}
