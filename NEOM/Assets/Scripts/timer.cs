using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour {

    float tiempo = 5f;
    float inicio = 13f;

    [SerializeField] Text countdownText;

    private void Start()
    {
        tiempo = inicio;
    }

    private void Update()
    {
        tiempo -= 1 * Time.deltaTime;
        

        if(tiempo < 0 )
        {
            tiempo = 0;

            SceneManager.LoadScene("nivel 1");
        }
        else if (tiempo <= 4)
        {
            countdownText.color = Color.red;
        }
        countdownText.text = tiempo.ToString("0");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    
}
