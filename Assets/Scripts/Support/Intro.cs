using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	[SerializeField]
	protected GameObject disableObj;

	[SerializeField]
	protected float activeDuration = 10.0f;

	[SerializeField]
	protected string sceneLoad;

	[SerializeField]
	protected float loadSceneIn;

	private float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(disableObj != null) {
			if(Time.time > startTime + activeDuration) {
				disableObj.SetActive(false);
			}
		}

		if(sceneLoad != null && sceneLoad.Length > 0) {
			if(Time.time > startTime + loadSceneIn) {
				Application.LoadLevel(sceneLoad);
			}
		}
	}
}
