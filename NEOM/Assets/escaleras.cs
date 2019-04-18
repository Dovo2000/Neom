using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class escaleras : MonoBehaviour {

    public bool inside = false; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            inside = !inside;
        }

    }
    void update()
    {
        if (inside == true && Input.GetKey("W"))
        {
         
        }
    }
}
