using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Weapon : MonoBehaviour {

    public Transform firePoint;
    public GameObject bulletPrefab;
    private int counterShots = 3;

    private float timeBtwShoots;
    private float startTimeBtwShoots = 0.5f;
    public Blink blink; 

    private void Start()
    {
        timeBtwShoots = startTimeBtwShoots;
    }

    // Update is called once per frame
    void Update() {

        if (counterShots > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(blink.Blinking());
                GetComponent<AudioSource>().Play();
                Shoot();       
                counterShots--;
            }
        }
        else
        {
            if (timeBtwShoots <= 0)
            {
                 timeBtwShoots = startTimeBtwShoots;
                counterShots = 3;
            }

            else
            {
                timeBtwShoots -= Time.deltaTime;
            }
        }
       
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

}
