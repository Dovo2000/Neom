using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {

    Animator animator; // Variable privada que referencia a l’animador
    bool doubleJumpAllowed = false;
    bool onGround = false;
    
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>(); // Agafem l’animador del objecte de la jerarquia al que també tenim associat l’script a través del mètode “GetComponent”, definim que volem un tipus “Animator”
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }

        if (onGround)
        {
            doubleJumpAllowed = true;
        }

        if(onGround && Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20);
            animator.SetTrigger("Salta");
        }
        else if(doubleJumpAllowed && Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20);
            if (!onGround)
            {
                animator.SetTrigger("Salta");
            }
           
            doubleJumpAllowed = false;
        }
        // Activem triggers segons input previ
        
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(30, 0));
            if (onGround)
            {
                animator.SetTrigger("Camina");
            }
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-30, 0));
            if (onGround)
            {
                animator.SetTrigger("Camina");
            }
        }
        if (GetComponent<Rigidbody2D>().velocity.x == 0 && onGround)
        {
             animator.SetTrigger("Quieto");
            
        }

    }

}
