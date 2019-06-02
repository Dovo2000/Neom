using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame()
    {
        Musicafondo.instance.musicSource.pitch = 1f;
        Musicafondo.instance.musicSource.volume = soundCont.musicVolume;
        Musicafondo.instance.musicSource.Play();
        FinalTime.inicio = Time.realtimeSinceStartup;
        Player.health = 100;
        SceneManager.LoadScene("nivel 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Credits()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void Settings()
    {
        Musicafondo.instance.musicSource.pitch = 1f;
        Musicafondo.instance.musicSource.volume = soundCont.musicVolume;
        Musicafondo.instance.musicSource.Play();
        SceneManager.LoadScene("Settings");
    }

    public void ReturnMenu()
    {
        Musicafondo.instance.musicSource.pitch = 0.9f;
        Musicafondo.instance.musicSource.volume = 0.2f;
        Musicafondo.instance.musicSource.Play();
        SceneManager.LoadScene("Menu");
    }
}
