using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
   
    public float health;

    public void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            gameOver();
        }
    }

      public void gameOver()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

}
