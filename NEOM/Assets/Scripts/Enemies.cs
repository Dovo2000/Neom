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

    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(Flash());
        if (health <= 0)
        {

            Destroy(enemy);
            deathCounter++;
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
