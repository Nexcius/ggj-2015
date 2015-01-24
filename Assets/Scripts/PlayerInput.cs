using UnityEngine;
using System.Collections;


public class PlayerInput : MonoBehaviour
{
    public float gravity = -15f;
    public float runSpeed = 8f;
    public float groundDamping = 20f;
    public float inAirDamping = 5f;
    // public float jumpWaitTime = 2.0;

    [HideInInspector]
    public float rawMovementDirection = 1;
    //[HideInInspector]
    public float normalizedHorizontalSpeed = 0;

    CharacterController2D _controller;
    Animator _animator;
    public RaycastHit2D lastControllerColliderHit;

    [HideInInspector]
    public Vector3 velocity;

	private bool onLadder = false;


    void Awake()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController2D>();
        _controller.onControllerCollidedEvent += onControllerCollider;
    }


    void onControllerCollider(RaycastHit2D hit)
    {
        // bail out on plain old ground hits
        if (hit.normal.y == 1f)
            return;

        // logs any collider hits
        //Debug.Log( "flags: " + _controller.collisionState + ", hit.normal: " + hit.normal );
    }


	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Ladder") {
			onLadder = true;
			rigidbody2D.gravityScale = 0.0f;
		}
	}

	void OnTriggerExit2D(Collider2D coll) {
		if (coll.tag == "Ladder") {
			onLadder = false;
			rigidbody2D.gravityScale = 1.0f;
		}
	}

    void Update()
    {
        // grab our current velocity to use as a base for all calculations
        velocity = _controller.velocity;

        if (_controller.isGrounded)
            velocity.y = 0;


		if (onLadder) {
			velocity.y = 0.0f;
			
			if(Input.GetKey(KeyCode.W)) {
				velocity.y = 3.0f;
			}
			else if(Input.GetKey(KeyCode.S)) {
				velocity.y = -3.0f;
			}
		}


        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            normalizedHorizontalSpeed = 1;
            if (transform.localScale.x < 0f)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            if (_controller.isGrounded)
                _animator.Play(Animator.StringToHash("Run"));
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            normalizedHorizontalSpeed = -1;
            if (transform.localScale.x > 0f)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            if (_controller.isGrounded)
                _animator.Play(Animator.StringToHash("Run"));
        }
        else
        {
            normalizedHorizontalSpeed = 0;

            if (_controller.isGrounded)
                _animator.Play(Animator.StringToHash("Idle"));
        }


        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            //to avoid DOUBLE JUMP
            if (_controller.isGrounded)
            {
                var targetJumpHeight = 2f;
                velocity.y = Mathf.Sqrt(2f * targetJumpHeight * -gravity);
                _animator.Play(Animator.StringToHash("Jump"));
            }
        }





        // apply horizontal speed smoothing it
        var smoothedMovementFactor = _controller.isGrounded ? groundDamping : inAirDamping; // how fast do we change direction?
        velocity.x = Mathf.Lerp(velocity.x, normalizedHorizontalSpeed * rawMovementDirection * runSpeed, Time.deltaTime * smoothedMovementFactor);

        // apply gravity before moving
        velocity.y += gravity * Time.deltaTime;

        _controller.move(velocity * Time.deltaTime);
    }

}