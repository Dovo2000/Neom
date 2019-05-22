using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float speed = 2;
    public int detectionRate = 4;
    public int force = 40;
    public Transform detectionPoint;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int damage;
    private float timeBtwShoots;
    public float startTimeBtwShoots = 0.5f;
    public Animator animator;

    void Start()
    {
        timeBtwShoots = startTimeBtwShoots;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trigger"))
        {
            force *= -1;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    void FixedUpdate()
    {
        // Debug.Log("FixedUpdate");
        RaycastHit2D detectionInfo = Physics2D.Raycast(detectionPoint.position, detectionPoint.right, detectionRate);
        if (detectionInfo)
        {
           // Debug.Log("He chocado con algo de tipo " + detectionInfo.transform.tag);
            if (detectionInfo.transform.tag == "Player")
            {
                Debug.Log("Player detected");
                animator.SetFloat("Speed", 0);
                enemyShoot();
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(force, 0));
                animator.SetFloat("Speed", Mathf.Abs(force));
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(force, 0));
            animator.SetFloat("Speed", Mathf.Abs(force));
        }
    }

    void enemyShoot()
    {
        if (timeBtwShoots <= 0)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            timeBtwShoots = startTimeBtwShoots;
        }

        else
        {
            timeBtwShoots -= Time.deltaTime;
        }
    }
}