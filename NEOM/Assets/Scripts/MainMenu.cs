using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame()
    {
        MusicaMenu.instanceMenu.musicSource.Stop();
        Musicafondo.instance.musicSource.Play();
        FinalTime.inicio = Time.realtimeSinceStartup;
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
        MusicaMenu.instanceMenu.musicSource.Stop();
        Musicafondo.instance.musicSource.Play();
        SceneManager.LoadScene("Settings");
    }

    public void ReturnMenu()
    {
        Musicafondo.instance.musicSource.Stop();
        MusicaMenu.instanceMenu.musicSource.Play();
        SceneManager.LoadScene("Menu");
    }
}
