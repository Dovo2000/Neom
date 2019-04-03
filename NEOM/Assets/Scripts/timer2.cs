using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer2 : MonoBehaviour
{

    float tiempo = 20f;
 

    [SerializeField] Text countdownText;

    
    private void Update()
    {
        tiempo -= 1 * Time.deltaTime;


        if (tiempo < 0)
        {
            tiempo = 0;

            SceneManager.LoadScene(1);
        }
        countdownText.text = tiempo.ToString("0");
    }


}