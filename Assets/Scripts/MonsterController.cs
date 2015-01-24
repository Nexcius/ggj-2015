using UnityEngine;
using System.Collections;

public class MonsterController : Entity {
    private Vector2 startPos;
    private Vector2 patrolTo;

    [SerializeField]
    protected float speed = 1.0f;

	// Use this for initialization
	protected void Start() {
        startPos = new Vector2(transform.position.x, transform.position.y);
        Transform pTo = transform.FindChild("PatrolTo");
        patrolTo = new Vector2(pTo.position.x, pTo.position.y);
	}
	

    protected override void FixedUpdate()
    {
        if (transform.position.x < startPos.x ||
            transform.position.x > patrolTo.x)
        {
            speed *= -1.0f;
        }
        velocity.x = speed;
        base.FixedUpdate();
        
    }
}
