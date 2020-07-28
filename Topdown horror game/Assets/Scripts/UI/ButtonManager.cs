using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //reloads the scene
    public void Retry()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }

    //returns the player back to the menu
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    //quits the application
    public void Quit()
    {
        Application.Quit();
    }
}
