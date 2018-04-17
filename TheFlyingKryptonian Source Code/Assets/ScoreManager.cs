using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public GameObject redKryptonite; /* redKryptonite is an empty object of type GameObject, we have attached our Meteors sprite to 'redKryptonite' object from Unity3D Inspector */
    private Flight supPos; /* Class Flight Object */
    public Text[] scoresText; /* Text Type Array */
    /* Score Variables */
    private float scoreToAdd = 1;
    public float highscoreCounter = 0;
    public float scoreCounter;

	// Use this for initialization
	void Start () {
        /* Find Object of type Flight (Our Superman) and Objects of type Text to access Score and High Score text */
        supPos = FindObjectOfType<Flight>();
        scoresText = FindObjectsOfType<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        /* If our superman position on x is greater than meteor position on x, in short If superman passes a meteor */
		if (supPos.transform.position.x > redKryptonite.transform.position.x)
        {
            /* Add score to the score counter */
            scoreCounter += scoreToAdd * Time.deltaTime; /* For Time.deltaTime explanation, check Extra explanation note on BackgroundEffect.cs */
            scoresText[0].text = "Score: " + Mathf.Round(scoreCounter); /* since it's Float so round the score counter so that it shows only INT and update it to SCORE text */
        }
	}

    /* RESET score method, called upon when player is dead */
    public void ResetScore()
    {
        if (Mathf.Round(scoreCounter) > highscoreCounter) /* Checks if Score Counter is greater than High Score counter which is initially set to 0 for the first run of game */
        {
            highscoreCounter = scoreCounter; /* If yes then assign Score Counter to High Score counter */
            scoresText[1].text = "High Score: " + Mathf.Round(highscoreCounter); /* Update High Score text */
        }
        scoreCounter = 0; /* Reset Score to 0 */
        scoresText[0].text = "Score: " + scoreCounter; /* Update Score text */
    }
}
