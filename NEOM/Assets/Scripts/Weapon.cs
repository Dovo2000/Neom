using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public LineRenderer lineRenderer;
    public Transform firePoint;
    public int damage;
    Player player;
    Enemies enemy;
    private Transform target;

    // Update is called once per frame
    void Update() {
       
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Gun());
        }
       
    }

    public IEnumerator Gun()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        damage = 40;
        if (hitInfo)
        {
            enemy = hitInfo.transform.GetComponent<Enemies>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
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
    }
    
    public IEnumerator ShootGun()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        if ((Vector2.Distance(transform.position, target.position)) < 2)
        {
            damage = 60;
        }
        else if ((Vector2.Distance(transform.position, target.position)) > 2 && (Vector2.Distance(transform.position, target.position) < 6)) 
        {
            damage = 30;
        }
        else
        {
            damage = 5;
        }
        if (hitInfo)
        {
            enemy = hitInfo.transform.GetComponent<Enemies>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
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
    }

    public IEnumerator Rifle()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        damage = 10;
        if (hitInfo)
        {
            enemy = hitInfo.transform.GetComponent<Enemies>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
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
    }
}
