using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {

    Animator animator; // Variable privada que referencia a l’animador
    short doubleJumpCounter = 0;
    short maxJumps = 2;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>(); // Agafem l’animador del objecte de la jerarquia al que també tenim associat l’script a través del mètode “GetComponent”, definim que volem un tipus “Animator”
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        // Activem triggers segons input previ
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(30, 0));
            animator.SetTrigger("Camina");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-30, 0));
            animator.SetTrigger("Camina");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (doubleJumpCounter < maxJumps)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20);
                animator.SetTrigger("Salta");
                doubleJumpCounter++;
            }
        }
        if(!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKeyDown(KeyCode.UpArrow))
            animator.SetTrigger("Quieto");

    }

}
