using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 40;
    public GameObject impactEffect;
	// Use this for initialization
	void Start () {
        rb.velocity = transform.right * speed;
	}

    void Update()
    {
        //if(destroyBala)
        {
            //hazLaBalaInvisible
        }
        //if(currentTime-timeCount>x)
        {
            //destroyAnim
            //destroyBala
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        Enemies enemy = hitInfo.GetComponent<Enemies>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);

            //timeCount = currentTime;

            //destroyBala = true;
        }

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);

        /*if (!hitInfo.CompareTag("Ladder") || !hitInfo.CompareTag("Trigger"))
        {
            //Destroy(gameObject);

        } */
    }

}
