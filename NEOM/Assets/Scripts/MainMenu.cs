using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame()
    {
        Player.health = 100;
        SceneManager.LoadScene("nivel 1");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!!");
        Application.Quit();
    }

    public void Credits()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
