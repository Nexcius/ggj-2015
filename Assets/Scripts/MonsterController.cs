using UnityEngine;
using System.Collections;

public class MonsterController : Entity {
    private Vector2 startPos;
    private Vector2 patrolTo;

    [SerializeField]
    protected float speed = 1.0f;

	private Animator _animator;


	// Use this for initialization
	protected void Start() {

        startPos = new Vector2(transform.position.x, transform.position.y);
        Transform pTo = transform.FindChild("PatrolTo");
        patrolTo = new Vector2(pTo.position.x, pTo.position.y);

		_animator = GetComponent<Animator>();
	}
	

    protected override void FixedUpdate()
    {
        if (transform.position.x < startPos.x ||
            transform.position.x > patrolTo.x)
        {
            speed *= -1.0f;
        }
        velocity.x = speed;

		if (speed > 0.0f && transform.localScale.x > 0.0f) {
			transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		}
		else if (speed < 0.0f && transform.localScale.x < 0.0f) {
			transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		}

		_animator.Play(Animator.StringToHash("Walk"));

        base.FixedUpdate();
        
    }

    
}
