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

    [SerializeField] Text countdownText;

    private void Start()
    {
        tiempo = inicio;
        animatorTimer.SetFloat("Time", tiempo);
        playerHealth = Player.health;
        transform.localScale = new Vector3(tamanyo, tamanyo, tamanyo); 
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
        }
        else if (tiempo <= 5)
        {
            countdownText.color = Color.black;
            transform.localScale = new Vector3(tamanyo * 2f, tamanyo * 2f, tamanyo * 2f);
        }
        countdownText.text = tiempo.ToString("0");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    
}
