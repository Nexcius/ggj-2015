using UnityEngine;
using System.Collections;

public class CharacterInput : Entity {
	[SerializeField]
	private Vector2 jumpVector = new Vector2(0.0f, 5.0f);

	[SerializeField]
	protected float speed = 0.1f;

	// Use this for initialization
	protected override void Start () {
		base.Start();
	}

	protected override void Update () {

		Vector2 moveDir = new Vector2(0.0f, 0.0f);

		if (Input.GetKey (KeyCode.A)) 
		{
				moveDir.x= -1.0f;
		} else if (Input.GetKey (KeyCode.D)) 
		{
				moveDir.x = 1.0f;
		} else
		{
				moveDir.x = 0.0f;
		}

		//rigidbody2D.velocity = (moveDir * speed);

		if (!IsAirbound() && Input.GetKeyDown (KeyCode.Space)) {
			rigidbody2D.AddForce(jumpVector, ForceMode2D.Impulse);			
		}

		velocity.x = moveDir.x * speed;

		base.Update ();
	}
}
