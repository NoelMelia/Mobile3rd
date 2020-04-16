using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()//Play Game and Level 1 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ScoreScript.scoreValue = 0;
    }

    public void ExitGame()//Quit Game
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    public void SceneLoader(int SceneIndex)//Load any scene by number
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
