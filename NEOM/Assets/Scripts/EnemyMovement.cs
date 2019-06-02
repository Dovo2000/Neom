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
    public AudioClip shootAudio;

    public bool pause = false;

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
        if(Input.GetButtonDown("Pause"))
        {
            if (!pause)
                pause = true;
            else
                pause = false;
        }

        if (!pause)
        {
            RaycastHit2D detectionInfo = Physics2D.Raycast(detectionPoint.position, detectionPoint.right, detectionRate);
            if (detectionInfo)
            {

                if (detectionInfo.transform.tag == "Player")
                {

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
    }

    void enemyShoot()
    {
        if (timeBtwShoots <= 0)
        {
            
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Musicafondo.instance.PlaySingleEnemy(shootAudio);
            timeBtwShoots = startTimeBtwShoots;
        }

        else
        {
            timeBtwShoots -= Time.deltaTime;
        }
    }
}