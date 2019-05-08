using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour {

    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 40;
    // Use this for initialization
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
        if(!hitInfo.CompareTag("Ladder"))
            Destroy(gameObject);
    }

}
