using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public int health;

    
    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //gameOver();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
