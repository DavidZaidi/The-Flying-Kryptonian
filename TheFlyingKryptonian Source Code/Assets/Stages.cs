using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stages : MonoBehaviour
{
    Flight supPos; /* Flight class object */
    ScoreManager ScoreMObj; /* ScoreManager class object */
    public MeteorGenerator generator; /* MeteorGenerator class (script) object */
    public GameObject stageAttach; /* stageAttach is an empty object of type GameObject, we can attach our desired Game object to stageAttach from the Unity3D Inspector */

    // Use this for initialization
    void Start()
    {
        /* Singleton Pattern */
        ScoreMObj = FindObjectOfType<ScoreManager>(); /* Find the first active object of type ScoreManager and store it in variable */
        generator = FindObjectOfType<MeteorGenerator>(); /* Find the first active object of type MeteorGenerator and store it in variable */
        supPos = FindObjectOfType<Flight>(); /* Find the first active object of type Flight and store it in variable */
    }

    // Update is called once per frame
    void Update()
    {
        /* Levels Logic */
        if (ScoreMObj.scoreCounter >= 5 && ScoreMObj.scoreCounter < 10)
        {
            // LEVEL: EASY 
            /* When score crosses '5', tweaked/customize the Superman and Meteor Generator properties */
            supPos.moveSpeed = 7;
            supPos.jumpForce = 5;
            supPos.maxFallSpeed = 6;
            generator.meteorDistance = 8;
        }
        else if (ScoreMObj.scoreCounter >= 10 && ScoreMObj.scoreCounter < 15)
        {
            // LEVEL: MEDIUM
            /* When score crosses '10', tweaked/customize the Superman and Meteor Generator properties */
            supPos.moveSpeed = 9;
            supPos.jumpForce = 5;
            supPos.maxFallSpeed = 8;
            generator.meteorDistance = 7;
        }
        else if (ScoreMObj.scoreCounter >= 15 && ScoreMObj.scoreCounter < 20)
        {
            // LEVEL: HARD
            /* When score crosses '15', Makes it significantly harder to play  */
            supPos.moveSpeed = 11;
            supPos.jumpForce = 5;
            supPos.maxFallSpeed = 10;
            generator.meteorDistance = 6f;
        }
        else if (ScoreMObj.scoreCounter >= 20)
        {
            // LEVEL: INSANE!
            /* When score crosses '20', God forbid you're on your own! */
            supPos.moveSpeed = 13;
            supPos.jumpForce = 5;
            supPos.maxFallSpeed = 12;
            generator.meteorDistance = 4.5f;
        }
    }
}
