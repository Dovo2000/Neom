using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyNoMove : MonoBehaviour
{
    public int damage;
    private float timeBtwShoots;
    public float startTimeBtwShoots;
    public Transform firePoint;
    public LineRenderer lineRenderer;
    public int detectionRate = 4;
    bool detection = false;
    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void update()
    {
        RaycastHit2D detectionInfo = Physics2D.Raycast(target.position, target.right);
        Player player = detectionInfo.transform.GetComponent<Player>();

        if (player)
        {
            detection = true;
        }
        if(detection)
        {
            StartCoroutine(enemyShoot());

            if (player == false)
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
