using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour {

    float tiempo = 5f;
    public float inicio;

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

            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
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
