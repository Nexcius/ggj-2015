using UnityEngine;
using System.Collections;

public class Projectile : Entity {
    [SerializeField]
    protected float timeToLive = 5.0f;

    [SerializeField]
    protected float projectileSpeed = 2.0f;

	[SerializeField]
	protected GameObject monsterRespawnObj;
	private MonsterRespawn monsterRespawn;

	protected GameObject splatter;

	[SerializeField]
	protected GameObject ingameCamObject;
	private IngameCam ingameCam;

	// Use this for initialization
	void Start () {
		monsterRespawn = monsterRespawnObj.GetComponent<MonsterRespawn> ();
		ingameCam = ingameCamObject.GetComponent<IngameCam>();

		splatter = transform.FindChild ("Splatter").gameObject;
		//ingameCamObject.SetActive(false);

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
			monsterRespawn.RegisterForRespawn(col.gameObject, 10.0f);

			ingameCam.Play();
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

		transform.rigidbody2D.angularVelocity = 3000.0f;
    }

}
