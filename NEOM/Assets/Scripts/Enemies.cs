using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {

    public int _deathCounter;

    public GameObject enemy;
    public int health = 100;
    public float deathCounter = 0;

    public Color colorToTurnTo = Color.red;
    public Color colorByDefault = Color.white;

    public AudioClip deathSound;

    //public CameraShake cameraShake;

    public void TakeDamage(int damage)
    {
        health -= damage;
        //StartCoroutine(cameraShake.Shake(0.15f, 0.2f));
        StartCoroutine(Flash());

        if (health <= 0)
        {
            Musicafondo.instance.PlaySingle(deathSound);
            deathCounter++;
            Destroy(enemy);
        }
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
