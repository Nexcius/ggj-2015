using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Entity : MonoBehaviour {
	protected Vector2 velocity = new Vector2();


	protected virtual void Start () {

	}
	
	// Update is called once per frame
	protected virtual void Update () {
		transform.position = transform.position + (Vector3)(velocity * Time.deltaTime);
	}

	public bool IsAirbound() {
		return Mathf.Abs(rigidbody2D.velocity.y) > 0.001f;
	}
}
