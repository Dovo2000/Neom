﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextlevel1 : MonoBehaviour {

    public int index;

    public Enemies muerto1;
    public Enemies muerto2;
    public Enemies muerto3;
    public Animator animator;

    void Update()
    {
        if (muerto1.deathCounter == 1 && muerto3.deathCounter == 1 && muerto2.deathCounter == 1)
        {
            animator.SetBool("is open", true);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(muerto1.deathCounter == 1 && muerto3.deathCounter == 1 && muerto2.deathCounter == 1)
        {

            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

    }
 
}

