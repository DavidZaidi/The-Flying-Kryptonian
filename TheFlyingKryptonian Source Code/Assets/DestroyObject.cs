using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {
    public Transform destructionPoint; /* Transform type variable, can only hold Position, Size and Rotation of an object */
    // Use this for initialization
    void Start () {
        destructionPoint = GameObject.Find("Destruction Point").transform; /* Find GameObject with name 'Destruction Point' and access it Transform (Position, Scaling and Rotation) */
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < destructionPoint.position.x) /* If current position of x is less than destruction point position x */
        {
            Destroy(gameObject); /* Destory the object this script is attached to */
        }
	}
}
