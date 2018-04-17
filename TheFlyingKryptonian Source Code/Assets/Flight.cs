using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flight :  {
    /* SUPERMAN SPRITE PROPERTIES */
    public float moveSpeed;
    public float jumpForce;
    public float maxFallSpeed;
    /* END */
    Rigidbody2D supRigidbody; /* Object of Type Rigibody2D, Rigid Bodies can have physical aspects/properties like Velocity, Gravity will effect them, Linear Drag and etc */
	// Use this for initialization
	void Start () {
        supRigidbody = GetComponent<Rigidbody2D>();  /* Find the component having RigidBody2D which in this case is our Superman sprite */
	}
    void FixedUpdate()
    {
        supRigidbody.velocity = new Vector2(moveSpeed, supRigidbody.velocity.y);
        if (supRigidbody.velocity.y <= -maxFallSpeed)
        {
            supRigidbody.velocity = new Vector2(supRigidbody.velocity.x, -maxFallSpeed);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) /* Detects If Mouse Left-Click or Space is pressed */
        {
            /* Superman jumping effect
             Add JumpForce set through Unity3D Inspector to Y-AXIS of Superman on every frame */
            supRigidbody.velocity = new Vector2(supRigidbody.velocity.x, supRigidbody.velocity.y + jumpForce);
        }
	}

    /* Detects the collision of Superman with the Meteors, Colliders are used for Rigid Bodies so that Collisions can be detected */
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "RedKryptonite") /* If 'this script is attached to' object collied with object having tag (sort of name can be seen through Unity3D Hierarchy) RedKryptonite */
        {
            /* Then call the PlayerDied() method from GameManager class using static variable gameInstance basically detecting our either Player is dead or not */
            GameManager.gameInstance.PlayerDied();
        }
    }
}
