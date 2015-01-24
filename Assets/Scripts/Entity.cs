using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]
public class Entity : MonoBehaviour {
	protected Vector2 velocity = new Vector2();

    protected virtual void FixedUpdate()
    {
        transform.position = transform.position + (Vector3)(velocity * Time.deltaTime);
    }

}
