using UnityEngine;
using System.Collections;

public class Projectile : Entity {
    [SerializeField]
    protected float timeToLive = 5.0f;

    [SerializeField]
    protected float projectileSpeed = 2.0f;

	protected GameObject splatter;

	// Use this for initialization
	void Start () {
		splatter = transform.FindChild ("Splatter").gameObject;

	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    protected override void FixedUpdate()
    {
        if (IsActive())
        {
            timeToLive -= Time.deltaTime;
            base.FixedUpdate();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			splatter.SetActive(true);
			timeToLive = 0.75f;
			velocity = Vector2.zero;

			col.gameObject.SetActive(false);
		}
		if (col.gameObject.layer == LayerMask.NameToLayer ("World")) {
			gameObject.SetActive(false);
		}
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			// TRIGGER ENEMY
		}
	}


    public bool IsActive()
    {
        return timeToLive >= 0.0f;
    }

    public void Shoot(Vector2 pos, Vector2 dir, float timeToLive)
    {
		if(splatter != null)
			splatter.SetActive(false);

        transform.position = pos;
        velocity = dir.normalized * projectileSpeed;
        this.timeToLive = timeToLive;
        gameObject.SetActive(true);

    }

}
