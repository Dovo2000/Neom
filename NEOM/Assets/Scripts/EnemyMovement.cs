using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    int force = -40;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemyTrigger"))
        {
            force *= -1;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    void Update()
    {
        
        GetComponent<Rigidbody2D>().AddForce(new Vector2(force, 0));
    }
}
