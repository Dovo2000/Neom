using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {

    float tiempo = 0f;
    float inicio = 1f;

    [SerializeField] Text countdownText;
    [SerializeField] Transform Respawnpoint;

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

            transform.position = Respawnpoint.position;

        }
    }

    
}
