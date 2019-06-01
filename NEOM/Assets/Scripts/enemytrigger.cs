using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemytrigger : MonoBehaviour
{
    public EnemyMovement enemy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            enemy.force *= -1;
            enemy.transform.Rotate(0f, 180f, 0f);
        }
    }
}
