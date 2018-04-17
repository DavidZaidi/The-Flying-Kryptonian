using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; /* Scenes library */

public class GameManager : MonoBehaviour
{
    public Flight superman; /* Class Flight Object */
    public MeteorGenerator generator; /* Class MeteorGenerator Object */
    private Vector3 supermanStart; /* Vector3 variable (x,y and z coordinates) */
    private Vector3 generatorStart; /* Vector3 variable (x,y and z coordinates) */
    DestroyObject[] theMeteors; /* Type DestroyObject array */
    public static GameManager gameInstance; /* GameManager Static Variable */
    public GameObject gameOverText;  /* gameOverText is an empty object of type GameObject, we have attached our Game Over messages to 'gameOverText' object from Unity3D Inspector */
    public bool gameOver = false; /* For detecting wether game is over or not */
    ScoreManager ScoreMObj; /* Class ScoreManager Object */
    AudioSource flyingAudio; /* AudioSource object to attach our superman Flying sound */
    // Use this for initialization
    void Start()
    {
        supermanStart = superman.transform.position; /* Store superman which is a type Flight object, positions to supermanStart, a Vector3 */
        generatorStart = generator.transform.position; /* Store meteor generation start point to generatorStart */
        ScoreMObj = FindObjectOfType<ScoreManager>(); /* Find objects of type SceneManager in the current scene like High Score, Score etc */
        flyingAudio = FindObjectOfType<AudioSource>(); /* Find objects of AudioSource which will be our superman flying sound */
    }

    void Awake()
    {
        if (gameInstance == null)
        {
            gameInstance = this;
        }
        else if (gameInstance != this)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (gameOver == true && Input.GetKeyDown(KeyCode.Return)) /* If user presses Rerturn/Enter key, and gameOver is true */
        {
            ResetGame(); /* Call the ResetGame() Method Or SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); */
            ScoreMObj.ResetScore(); /* Call the ResetScore() Method from class ScoreManager using ScoreMObj because game is resetting so score should too */
            Time.timeScale = 1.0f; /* Unfreeze/Unpause the game */
        }
        if (gameOver == true && Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene(0);
        }
        /*
         * For Android Platform
            if (Application.platform == RuntimePlatform.Android)
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    SceneManager.LoadScene(0);
                    Time.timeScale = 1.0f;
                }
            }
        */
    }

    /* ResetGame() Method called upon when gameOver is True and user presses "Return/Enter" key */
    public void ResetGame()
    {
        superman.transform.position = supermanStart; /* Reset the superman position */
        generator.transform.position = generatorStart; /* Reset the meteor generation position */
        theMeteors = FindObjectsOfType<DestroyObject>(); /* Find all the objects having type DestroyObject, in our case, METEORS */
        for (int i = 0; i < theMeteors.Length; i++) /* Count the number of total meteors */
        {
            Destroy(theMeteors[i].gameObject); /* Destroy all the previous meteors because game is resetting */
        }
        gameOverText.SetActive(false); /* Hide the GameOver text */
        gameOver = false; /* Set gameOver to false */
        superman.moveSpeed = 5; /* Reset the Default moveSpeed, because it gets changed in Stages.cs */
        superman.jumpForce = 6; /* Reset the Default jumpForce, because it gets changed in Stages.cs */
        superman.maxFallSpeed = 4; /* Reset the Default maxFallSpeed, because it gets changed in Stages.cs */
        generator.meteorDistance = 14; /* Reset the Default meteorDistance, because it gets changed in Stages.cs */
        flyingAudio.mute = false; /* Unmute the Flying Audio */
    }

    /* PlayerDied() Method called upon when the Player is dead */
    public void PlayerDied()
    {
        gameOverText.SetActive(true); /* Show the GameOver text on screen */
        gameOver = true; /* Set gameOver to True */
        Time.timeScale = 0; /* Freeze the screen */
        flyingAudio.mute = true; /* Mute the Flying sound */
    }
}
