using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class respawntest : MonoBehaviour {

    [SerializeField] Transform Respawnpoint;

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            collision.transform.position = Respawnpoint.position;
    }


}
