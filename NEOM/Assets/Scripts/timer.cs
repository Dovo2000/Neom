using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour {

    float tiempo = 5f;
    public float inicio;
    private float playerHealth;
    public Animator animatorTimer;
    public float tamanyo = 1;
    float posicionamiento1, posicionamiento2;

    [SerializeField] Text countdownText;

    private void Start()
    {
        tiempo = inicio;
        animatorTimer.SetFloat("Time", tiempo);
        playerHealth = Player.health;
        transform.localScale = new Vector3(tamanyo, tamanyo, tamanyo);
        posicionamiento1 = transform.position.y - 0.15f;
        posicionamiento2 = transform.position.y - 0.33f;

    }

    private void Update()
    {
        tiempo -= 1 * Time.deltaTime;
        animatorTimer.SetFloat("Time", tiempo);
        

        if(tiempo < 0 )
        {
            tiempo = 0;
            Player.health = playerHealth;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        else if(tiempo <= 10 && tiempo > 5)
        {
            countdownText.color = Color.yellow;
            transform.localScale = new Vector3(tamanyo * 1.5f, tamanyo * 1.5f, tamanyo);
            transform.position = new Vector3(0, posicionamiento1, 0);
        }
        else if (tiempo <= 5)
        {
            countdownText.color = Color.black;
            transform.localScale = new Vector3(tamanyo * 2f, tamanyo * 2f, tamanyo * 2f);
            transform.position = new Vector3(0, posicionamiento2, 0);
        }
        countdownText.text = tiempo.ToString("0");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    
}
