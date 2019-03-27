using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento2 : MonoBehaviour {
    Animator animator; // Variable privada que referencia a l’animador
    private bool doubleJumpAllowed = false;
    bool onGround = false;
    float originalXScale = 2.5f;   //
    int direction;      // Direcció a la que mira el player

    private static bool DEBUG = false;
    
    // Use this for initialization
    void Start() {
        if(DEBUG) animator = GetComponent<Animator>(); // Agafem l’animador del objecte de la jerarquia al que també tenim associat l’script a través del mètode “GetComponent”, definim que volem un tipus “Animator”
    }

    // Update is called once per frame
    void FixedUpdate() {
        Debug.Log(" NEXT FRAME! doubleJumpAllowed is " + doubleJumpAllowed);
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

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (onGround)
            {
                GetComponent<Rigidbody2D>().velocity = (new Vector2(0, 20));
                if (DEBUG) animator.SetTrigger("Salta");
            }
            else if (doubleJumpAllowed)
            {
                
                GetComponent<Rigidbody2D>().velocity = (new Vector2(0, 15));
                if (!onGround)
                {
                    if (DEBUG) animator.SetTrigger("Salta");
                }

                doubleJumpAllowed = false;
                
            }
        }
        // Activem triggers segons input previ

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity =  (new Vector2(20 * getInput(), GetComponent<Rigidbody2D>().velocity.y));
            if (onGround)
            {
                direction = 1;
                FlipCharacterDirection();
                if (DEBUG) animator.SetTrigger("Camina");
            }

        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity =  (new Vector2(-20 * getInput(), GetComponent<Rigidbody2D>().velocity.y));
            if (onGround)
            {
                direction = -1;
                FlipCharacterDirection();
                if (DEBUG) animator.SetTrigger("Camina");
            }
        }
        if (GetComponent<Rigidbody2D>().velocity.x == 0 && onGround)
        {
            if (DEBUG) animator.SetTrigger("Quieto");
        }


        // Activem triggers segons input previ
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(30, 0));
            if (DEBUG) animator.SetTrigger("Camina");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-30, 0));
            if (DEBUG) animator.SetTrigger("Camina");
        }
        if (onGround && Input.GetKeyDown(KeyCode.UpArrow))
        {
            
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20);
            if (DEBUG) animator.SetTrigger("Salta");
            
        }
        else if (doubleJumpAllowed && Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 15);
            if (!onGround)
            {
                if (DEBUG) animator.SetTrigger("Salta");
            }

            doubleJumpAllowed = false;
        }
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKeyDown(KeyCode.UpArrow))
            if (DEBUG) animator.SetTrigger("Quieto");

        
    }
    void FlipCharacterDirection()
    {

        Vector3 scale = transform.localScale; // Guarda la escala local

        scale.x = originalXScale * direction; // Inverteix la escala 

        transform.localScale = scale; // Aplica la rotació

    }
    int getInput()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            return 1;
        }
        else return 0;
    }
    
}

