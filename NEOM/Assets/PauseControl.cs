using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseControl : MonoBehaviour {

    Canvas canvas;
    public Canvas canvasOpciones;

    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvasOpciones.enabled = false;
        canvas.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (Time.timeScale == 1) FinalTime.inicioPausa = Time.realtimeSinceStartup;
        else if (Time.timeScale == 0) FinalTime.finalPausa = Time.realtimeSinceStartup;
        canvas.enabled = !canvas.enabled;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    public void Resume()
    {
        FinalTime.finalPausa = Time.realtimeSinceStartup;
        canvas.enabled = false;
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        canvas.enabled = false;
        Time.timeScale = 1;
        FinalTime.inicioPausa = 0f;
        FinalTime.finalPausa = 0f;
        Musicafondo.instance.musicSource.pitch = 0.9f;
        Musicafondo.instance.musicSource.volume = 0.2f;
        Musicafondo.instance.musicSource.Play();
        SceneManager.LoadScene("Menu");
    }

    public void Opciones()
    {
        canvasOpciones.enabled = true;
    }

    public void Back()
    {
        canvasOpciones.enabled = false;
    }
}
