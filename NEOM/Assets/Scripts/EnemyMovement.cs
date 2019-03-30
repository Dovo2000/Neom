using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float speed = 2;
    public int detectionRate = 4;
    bool detection = false;
    int force = 40;
    private Transform target;
    public Transform firePoint;
    public LineRenderer lineRenderer;
    public int damage;
    private float timeBtwShoots;
    public float startTimeBtwShoots;
    private float timeLine;
    public float startTimeLine;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        timeBtwShoots = startTimeBtwShoots;
        timeLine = startTimeLine;
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

            StartCoroutine(enemyShoot());


            if ((Vector2.Distance(transform.position, target.position) > detectionRate))
            {
                detection = false;
            }
        }
    }

    IEnumerator enemyShoot()
    {
        if (timeBtwShoots <= 0)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

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

            lineRenderer.enabled = false;

            timeBtwShoots = startTimeBtwShoots;
        }

        else if (timeBtwShoots > 0)
        {
            timeBtwShoots -= Time.deltaTime;
        }
    }
}