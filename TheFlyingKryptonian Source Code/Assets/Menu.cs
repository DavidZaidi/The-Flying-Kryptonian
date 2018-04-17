using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    AudioSource introAudio; /* AudioSource object which will hold our Intro music source */
    Text[] menuTextArr; /* Array object of type Text which holds the Texts shown on the Menu */
    public void Start()
    {
        /* Singleton Pattern */
        introAudio = GetComponent<AudioSource>(); /* Find the component assigned Audio Source */
        menuTextArr = FindObjectsOfType<Text>(); /* Find all the objects of Type Text */
    }

    /* Method for New Game */
    public void NewGameStart()
    {
        /* Unity3D allow us to assign Indexes to our Scenes */
        SceneManager.LoadScene(1); /* It will load the scene having index '1' which is our Game scene upon Calling */
    }

    /* Muting and Unmuting audio/intro music Method added to 'Mute' Button Click Event from Inspector */
    public void MuteAudio()
    {
        introAudio.mute = !introAudio.mute;
        if (introAudio.mute == true)
        {
            introAudio.Pause(); /* Pause the audio attached to introAudio */
            menuTextArr[2].text = "Unmute"; /* Change the text of Type Text having index 2 with Unmute */
        }
        else
        {
            introAudio.UnPause(); /* Unpause the audio attached to introAudio */
            menuTextArr[2].text = "Mute"; /* Change the text of Type Text having index 2 with Mute */
        }
    }

    /* Game Quitting Method called upon 'Exit' button click event */
    public void GameQuit()
    {
        Application.Quit(); /* Self explanatory */
    }
}
