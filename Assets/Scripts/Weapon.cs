using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    [SerializeField]
    protected GameObject aimRetricle;
    private Retricle aimRetricleScript;

    [SerializeField]
    protected GameObject projectileBase;

    private GameObject[] projectiles;
    private Projectile[] projectileScripts;

    private const int PROJECTILE_COUNT = 15;

    [SerializeField]
    protected float projectileTimeToLive = 5.0f;

	// Use this for initialization
	void Start () {
        aimRetricleScript = aimRetricle.GetComponent<Retricle>();

        projectiles = new GameObject[PROJECTILE_COUNT];
        projectileScripts = new Projectile[PROJECTILE_COUNT];

        for (int i = 0; i < PROJECTILE_COUNT; i++)
        {
            projectiles[i] = (GameObject)Instantiate(projectileBase, transform.position, Quaternion.identity);
            projectiles[i].SetActive(false);

            projectileScripts[i] = projectiles[i].GetComponent<Projectile>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            int pId = GetAvailableProjectile();
            if (pId >= 0.0f)
            {
                projectileScripts[pId].Shoot(transform.position, aimRetricleScript.GetAimDir(), projectileTimeToLive);
            }
        }
	}

    private int GetAvailableProjectile()
    {
        for (int i = 0; i < projectiles.Length; i++)
        {
            if (!projectiles[i].activeSelf)
            {
                return i;
            }
        }

        return -1;
    }
}
