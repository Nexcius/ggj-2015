using UnityEngine;
using System.Collections;


public class IngameCam : MonoBehaviour {

	[SerializeField]
	protected float sfinxDuration = 9.0f;

	[SerializeField]
	protected float napoleonDuration = 9.0f;

	private float duration = 0.0f;
	private string clip = "sfinx";

	private float startTime = 0.0f;
	Animator _animator;

	void Start() {
		_animator = GetComponent<Animator>();
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		//_animator.Play(Animator.StringToHash("sfinx"));
		_animator.Play(Animator.StringToHash(clip));
		if(startTime + duration < Time.time) {
			gameObject.SetActive(false);
		}
	}


	public void Play() {
		if(gameObject.activeSelf) {
			return;
		}

		if(Random.value > 0.5f) {
			duration = napoleonDuration;
			clip = "napoleon";
		}
		else {
			duration = sfinxDuration;
			clip = "sfinx";
		}

		startTime = Time.time;
		gameObject.SetActive (true);
	}
}
