using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundEffect : MonoBehaviour
{
    public float scrollSpeed; /* Background scolling speed */
    Vector2 backgroundPosition; /* A vector2 (x and y coordinates) which will hold Background position */
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BackgroundScrolling(); /* Calls BackgroundScrolling() each frame */
    }

    /* Method for Background Effect/Scrolling */
    void BackgroundScrolling()
    {
        /*
        1st Line: Set backgroundPosition of x axis to Time.time * scrollSpeed 
        2nd Line: Find the Rnderer component and set it's Offset to backgroundPosition, this line will apply the scrollSpeed to our Background image so it will repeat itself */

        backgroundPosition = new Vector2(Time.time * scrollSpeed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = backgroundPosition;

        /* IMPORTANT NOTE:
         Our game is Time-based not Framerate based so Time.time is the time in seconds since the start of the game so it will take the real-world time
         and then multiplied it with our scrollSpeed. 
         EXTRA EXPLANATION: Different PCs have different specifications so if our game was Framerate then our game will work DIFFERENTLY ON DIFFERENT PCs
         to avoid this we used Time library so on Every PC our game works same */
    }
}
