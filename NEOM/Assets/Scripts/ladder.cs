using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour {

    public float velo = 6;
   
    // Use this for initialization
    void start(){
        }
    void update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player" && Input.GetKey(KeyCode.W))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2  (0, velo);
        }
       else if (other.tag == "Player" && Input.GetKey(KeyCode.S))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -velo);
        }
        else if(other.tag == "Player" && Input.GetKey(KeyCode.S) == false && other.tag == "Player" && Input.GetKey(KeyCode.W) == false)
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0.82f);
        }
    }
}
