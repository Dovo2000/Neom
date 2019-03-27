using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {
    public GameObject enemy;
    public int health = 100;


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {

            Destroy(enemy);
        }
    }
    
    // Update is called once per frame
    void Update()
    {

        
    }
}
