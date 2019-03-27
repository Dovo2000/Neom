using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {
    public GameObject enemy;
    public int health = 100;
    public int weaponType = 0;     //0: GUN, 1:SHOOTGUN, 2:RIFLE
    Weapon enemyWeapon;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {

            Destroy(enemy);
        }
    }
    
    public void Weapon()
    {
        if (weaponType == 0)
        {
            enemyWeapon.StartCoroutine(enemyWeapon.Gun());
        }
        else if (weaponType == 1)
        {
            enemyWeapon.StartCoroutine(enemyWeapon.ShootGun());
        }
        else
        {
            enemyWeapon.StartCoroutine(enemyWeapon.Rifle());
        }
    }
}
