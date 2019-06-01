using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextlevel4 : MonoBehaviour
{
    
    public int index;

    public Enemies muerto1;
    public Enemies muerto2;
    public Enemies muerto3;
    public Enemies muerto4;
    public Animator animator;


    void Update()
    {
        if (muerto1.deathCounter == 1 && muerto3.deathCounter == 1 && muerto2.deathCounter == 1 && muerto4.deathCounter == 1)
        {
            animator.SetBool("is open", true);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (muerto1.deathCounter == 1 && muerto3.deathCounter == 1 && muerto2.deathCounter == 1 && muerto4.deathCounter == 1)
        {

            if (other.CompareTag("Player"))
            {
                Musicafondo.instance.musicSource.Stop();
                MusicaMenu.instanceMenu.musicSource.Play();
                SceneManager.LoadScene("Menu");

            }
        }

    }

}
