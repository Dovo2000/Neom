using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Weapon : MonoBehaviour {

    public LineRenderer lineRenderer;
    public Transform firePoint;
    public int damage = 40;
    enum WeaponTypes { GUN, SHOOTGUN, RIFLE };
   

    // Update is called once per frame
    void Update() {
        
            if (Input.GetButtonDown("Fire1"))
            {
                GetComponent<AudioSource>().Play();
                StartCoroutine(Shoot());
            }
       
    }

    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            Enemies enemy = hitInfo.transform.GetComponent<Enemies>();
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
