﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour {

    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 40;
    public GameObject EnemyEffect;
 
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.takeDamage(damage);
        }
      Instantiate(EnemyEffect, transform.position, transform.rotation);

        if(!hitInfo.CompareTag("Ladder") || !hitInfo.CompareTag("Trigger"))
            Destroy(gameObject);
    }

}
