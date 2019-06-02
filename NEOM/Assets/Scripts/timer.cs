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
    public Color cambio1 = Color.red;
    public Color cambio2 = Color.black;
    public Color cambio3 = Color.white;

    public bool pause = false;


    [SerializeField] Text countdownText;

    private void Start()
    {
        tiempo = inicio;
        animatorTimer.SetFloat("Time", tiempo);
        playerHealth = Player.health;
        transform.localScale = new Vector3(tamanyo, tamanyo, tamanyo);
        posicionamiento1 = transform.position.y - 0.15f;
        posicionamiento2 = transform.position.y - 0.33f;
        countdownText.color = Color.green;
        GetComponent<Text>().material.color = cambio3;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (!pause)
                pause = true;
            else
                pause = false;
        }


        if (!pause)
        {
            tiempo -= 1 * Time.deltaTime;
            animatorTimer.SetFloat("Time", tiempo);


            if (tiempo < 0)
            {
                tiempo = 0;
                Player.health = playerHealth;
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
            else if (tiempo <= 10 && tiempo > 5)
            {
                countdownText.color = Color.yellow;
                transform.localScale = new Vector3(tamanyo * 1.5f, tamanyo * 1.5f, tamanyo);
                transform.position = new Vector3(0, posicionamiento1, 0);
            }
            else if (tiempo <= 5 && tiempo > 0)
            {
                StartCoroutine(FlashChrono());
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

    IEnumerator FlashChrono()
    {
        for (int n = 0; n < 10; n++)
        {
            Debug.Log(GetComponent<Text>().material.name);
            GetComponent<Text>().color = cambio1;
            yield return new WaitForSeconds(0.2f);
            GetComponent<Text>().color = cambio2;
            yield return new WaitForSeconds(0.2f);
        }
    }    
}
