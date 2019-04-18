using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public float health;
   
    public Color colorToTurnTo = Color.red;
    public Color colorByDefault = Color.white;
   

    public void takeDamage(float damage)
    {

        health -= damage;
        if (health <= 0)
        {
            gameOver();
        }
        StartCoroutine(Flash());
        

    }

    public void gameOver()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    IEnumerator Flash()
    {
        for (int n = 0; n < 2; n++)
        {
            GetComponent<Renderer>().material.color = colorToTurnTo;
            yield return new WaitForSeconds(0.1f);
            GetComponent<Renderer>().material.color = colorByDefault;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
               
                
