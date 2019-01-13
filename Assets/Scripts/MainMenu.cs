using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame() // this function is used to call the next scene, baced on the hierarchy in the build settings menu in unity 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public void QuitGame()
    { 
        Application.Quit(); // this function exits the application when the quit button is pressed
    }
}