using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour {

    float tiempo = 0f;
    float inicio = 10f;

    [SerializeField] Text countdownText;

    private void Start()
    {
        tiempo = inicio;
    }

    private void Update()
    {
        tiempo -= 1 * Time.deltaTime;
        countdownText.text = tiempo.ToString("0");

        if(tiempo <= 0 )
        {
            tiempo = 0;

            SceneManager.LoadScene(0);
        }
    }

    
}
