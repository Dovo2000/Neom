using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextlevel1 : MonoBehaviour {

    public int index;

    public Enemies muerto1;
    public Enemies muerto2;
    public Enemies muerto3;
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && muerto1.deathCounter == 1 && muerto3.deathCounter == 1 && muerto2.deathCounter == 1)
        {

            Debug.Log("Colisiona con la puerta");
               SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            

        }

    }
 
}

