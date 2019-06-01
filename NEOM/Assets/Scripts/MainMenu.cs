using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame()
    {
        MusicaMenu.instanceMenu.musicSource.Stop();
        Musicafondo.instance.musicSource.Play();
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

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
