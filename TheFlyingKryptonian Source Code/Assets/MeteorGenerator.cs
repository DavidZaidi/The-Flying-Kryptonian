using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorGenerator : MonoBehaviour {
    public GameObject meteors;  /* meteors is an empty object of type GameObject, we have attached our Meteor sprite to 'meteors' object from Unity3D Inspector */
    // START
    /* Variables for Meteor generation which will hold all the relevant properties like Size, Distance inbetween and Position */
    public float maxHeight;
    public float minHeight;
    public float meteorDistance;
    public float minScale;
    public float maxScale;
    // END
    public Transform generatorThreshold; /* Transform type variable, can only hold Position, Size and Rotation of an object */

	// Use this for initialization
	void Start () {
        /* Set the current position (Coordinates) and add whatever the meteorDistance is (Set through Inspector) in x axis (Horizontal position) */
        transform.position = new Vector3(transform.position.x + meteorDistance, transform.position.y, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < generatorThreshold.position.x) /* Checks if current position is less than Generation Point */
        {
            /*
             1st Line: Instantiate (Clone) the object meteor with same x axis and on y axis randomly change the y coordinate as per to the given Range and save it in meteorInstantiate
             2nd Line: Changes the size (scaling) of the meteor with a random range of x and y coordinates given through Unity3D
             3rd Line: Set the current position (Coordinates) and add whatever the meteorDistance is (Set through Inspector) in x axis (Horizontal position) for next meteor Generation
            */
            var meteorInstantiate = Instantiate(meteors, new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), transform.position.z), transform.rotation);
            meteorInstantiate.transform.localScale = new Vector3(Random.Range(minScale, maxScale), Random.Range(minScale, maxScale),transform.localScale.z);
            transform.position = new Vector3(transform.position.x + meteorDistance, transform.position.y, transform.position.z);
        }
	}
}
