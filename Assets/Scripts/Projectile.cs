using UnityEngine;
using System.Collections;

public class Projectile : Entity {
    [SerializeField]
    protected float timeToLive = 5.0f;

    [SerializeField]
    protected float projectileSpeed = 2.0f;

	// Use this for initialization
	void Start () {
	
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

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("World"))
        {
            gameObject.SetActive(false);
        }
    }

    public bool IsActive()
    {
        return timeToLive >= 0.0f;
    }

    public void Shoot(Vector2 pos, Vector2 dir, float timeToLive)
    {
        transform.position = pos;
        velocity = dir.normalized * projectileSpeed;
        this.timeToLive = timeToLive;
        gameObject.SetActive(true);
    }

}
