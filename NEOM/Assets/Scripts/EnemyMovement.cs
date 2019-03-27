using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float speed = 2;
    public int detectionRate = 4;
    bool detection = false;
    int force = 40;
    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trigger"))
        {
            force *= -1;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    void Update()
    {
        if ((Vector2.Distance(transform.position, target.position) < detectionRate))
        {
            detection = true;
        }
        
        if (detection == false)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(force, 0));
        }
        else
        {
            
            if ((Vector2.Distance(transform.position, target.position) > detectionRate))
            {
                detection = false;
            }
        }
    }
}
