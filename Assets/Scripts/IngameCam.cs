using UnityEngine;
using System.Collections;

public class IngameCam : MonoBehaviour {

	[SerializeField]
	protected float duration = 9.0f;

	private float startTime = 0.0f;
	
	// Update is called once per frame
	void Update () {
		if(startTime + duration < Time.time) {
			gameObject.SetActive(false);
		}
	}

	public void Play() {
		startTime = Time.time;
		gameObject.SetActive (true);
	}
}
