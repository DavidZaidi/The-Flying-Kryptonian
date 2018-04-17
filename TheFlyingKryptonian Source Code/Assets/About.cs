using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class About : MonoBehaviour {
    public GameObject Window;  /* Window is an empty object of type GameObject, we have attached our 'About' popup to it */
    public Text messageField; /* Variable of Type Text which will hold About poput text */

    /* Method called upon Click Event of 'About' button on Menu */
    public void Show(string message)
    {
        messageField.text = message; /* Set the text to message given from Unity3D Inspector */
        Window.SetActive(true); /* Initially It is false, invisible and on About button click event, visible the text */
    }

    /* Method for OK button called upon Click Event in About */
    public void hide()
    {
        Window.SetActive(false); /* Set it to false, the popup will become invisible */
    }
}
