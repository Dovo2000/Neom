﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float speed = 2;
    public int detectionRate = 4;
    public int force = 40;
    public Transform detectionPoint;
    //public Transform detectionPointBack;
    public Transform firePoint;
    //public LineRenderer lineRenderer;
    public GameObject bulletPrefab;
    public int damage;
    private float timeBtwShoots;
    public float startTimeBtwShoots = 0.5f;
    public Animator animator;

    void Start()
    {
        timeBtwShoots = startTimeBtwShoots;
        //detectionPointBack.transform.Rotate(0f, 180f, 0f);
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
        //RaycastHit2D detectionInfoBack = Physics2D.Raycast(detectionPointBack.position, detectionPointBack.right, detectionRate-3);
        if (detectionInfo /*|| detectionInfoBack*/)
        {
           // Debug.Log("He chocado con algo de tipo " + detectionInfo.transform.tag);
            if (detectionInfo.transform.tag == "Player")
            {
                Debug.Log("Player detected");
                //StartCoroutine(enemyShoot());
                animator.SetFloat("Speed", 0);
                enemyShoot();
            }
            /*else if(detectionInfoBack.transform.tag == "Player")
            {
                force *= -1;
                transform.Rotate(0f, 180f, 0f);
                animator.SetFloat("Speed", 0);
                enemyShoot();
            }*/
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
            /*RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

            if (hitInfo)
            {
                Player player = hitInfo.transform.GetComponent<Player>();

                if (player != null)
                {
                    player.takeDamage(damage);
                }
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, hitInfo.point);
            }
            else
            {
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
            }

            lineRenderer.enabled = true;

            yield return 1;

            lineRenderer.enabled = false;*/

            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            timeBtwShoots = startTimeBtwShoots;
        }

        else if (timeBtwShoots > 0)
        {
            timeBtwShoots -= Time.deltaTime;
        }
    }
}