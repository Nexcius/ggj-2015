using UnityEngine;
using System.Collections;

public class Retricle : MonoBehaviour {
    private GameObject player; 

    [SerializeField]
    protected float distanceFromPlayer = 5.0f;

    protected Vector2 aimDir;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
    void OnGUI()
    {
		if (Input.mousePosition != null) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            aimDir = mousePos - (Vector2)player.transform.position;
            aimDir.Normalize();

            Vector2 aimPos = (Vector2)player.transform.position + (aimDir * distanceFromPlayer);

            transform.position = aimPos;
		} 	
	}

    public Vector2 GetAimDir()
    {
        return aimDir;
    }
}
