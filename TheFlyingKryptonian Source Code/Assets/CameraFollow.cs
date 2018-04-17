using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject objectToFollow; /* objectToFollow is an empty object of type GameObject, we have attached our Superman sprite to 'objectToFollow' object from Unity3D Inspector */
    /* Camera Follow Properties */
    float previousPosition;
    float amountToMove;
	// Use this for initialization
	void Start () {
        /* 
        1st Line: timeScale is a time property which pauses and unpauses the game, where 1.0f stands for Realtime (unpause) and 0 stands for freeze (pause) 
        2nd Line: Store objecToFollow positions to previousPosition so that we can use it in Update and move the camera */
        Time.timeScale = 1.0f;
        previousPosition = objectToFollow.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        /*
        1st Line: Amount of camera to move and store it in variable, a simple formula which will calculate the amount to move
        2nd Line: Set the current position to amountToMove on x axis and add it on every frame 
        3rd Line: Update the previous position so that we can move forward horizontally
        This process will repeat on every frame so that our Camera can follow/move with the Superman sprite
         */
        amountToMove = (objectToFollow.transform.position.x + 5f) - previousPosition;
        transform.position += new Vector3(amountToMove, 0f, 0f);
        previousPosition = transform.position.x;
	}
}
