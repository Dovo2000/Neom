using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{

    public Animator animator;
    public bool drawDebugRaycast = true;        //Para dibujar el raycast que comprueba el entorno
    Weapon firePoint;
   

    [Header("Movement Properties")]
    public float speed = 8f;
    public float crouchSpeedDivisor = 3f;
    public float maxFallSpeed = -25f;
    /*
    [Header("Jump Properties")]
    public float jumpForce = 22.5f;
    public float doubleJumpForce = 10.7f;
    public int doubleJumpCounter = 0;
    */
    [Header("Enviroment Check Properties")]
    public float feetOffset = 0f;
    public float headDistance = 0.2f;
    public float groundDistance = 0.2f;
    public LayerMask groundLayer;

    [Header("Player Status")]
    public bool isOnGround;
    public bool isJumping;
    public bool doubleJumpAllowed;
    public bool isCrouching;
    public bool isHeadBlocked;
   

    PlayerInput input;                          //Input recibido
    BoxCollider2D bodyCollider;
    Rigidbody2D rigidBody;
 

    float playerHeight;

    int direction = 1;

    Vector2 colliderStandSize;
    Vector2 colliderStandOffset;
    Vector2 colliderCrouchSize;
    Vector2 colliderCrouchOffset;


    // Use this for initialization
    void Start()
    {
        groundLayer = LayerMask.GetMask("Default");
        // Cogiendo referencias
        input = GetComponent<PlayerInput>();
        rigidBody = GetComponent<Rigidbody2D>();
        bodyCollider = GetComponent<BoxCollider2D>();
        // Guarda la altura del boxCollider
        playerHeight = bodyCollider.size.y;

        // Guarda la size y offset inicial del collider
        colliderStandSize = bodyCollider.size;
        colliderStandOffset = bodyCollider.offset;

        // Calcula la altura y el offset al estar agachado
        colliderCrouchSize = new Vector2(bodyCollider.size.x, playerHeight / 1.75f);
        colliderCrouchOffset = new Vector2(bodyCollider.offset.x, bodyCollider.offset.y / 1.75f);

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Comprobar el entorno lanzando rayos desde el player
        PhysicsCheck();

        //Procesar Movimiento
        GroundMovement();
        //MidAirMovement();

    }

    void PhysicsCheck()
    {
        isOnGround = false;
        isHeadBlocked = false;

        RaycastHit2D underCheck = Raycast(new Vector2(feetOffset, (-playerHeight)-0.3f), Vector2.down, groundDistance);

        if (underCheck)
            isOnGround = true;

        // Raycast para comprobar la si la cabeza está bloqueada

        RaycastHit2D headCheck = Raycast(new Vector2(0f, bodyCollider.size.y * 2.2f), Vector2.up, headDistance);

        if (headCheck)
        {
            isHeadBlocked = true;
            // Debug.Log("Cabeza blockeeada!! el objeto que la bloquea es: "+headCheck.transform.tag);
        }

    }

    void GroundMovement()
    {
        if(input.crouchHeld && !isCrouching && isOnGround)
        {
            Crouch();
        }
        else if(!input.crouchHeld && isCrouching)
        {
            StandUp();
        }
        else if(!isOnGround && isCrouching)
        {
            StandUp();
        }

        float xVelocity = speed * input.horizontal;

        animator.SetFloat("Speed", Mathf.Abs(xVelocity));

        if (xVelocity * direction < 0f)
            FlipCharacterDirection();

        if (isCrouching)
            xVelocity /= crouchSpeedDivisor;

        rigidBody.velocity = new Vector2(xVelocity, rigidBody.velocity.y);
    }

    /*void MidAirMovement()
    {
        
        
        if(input.jumpPressed && !isJumping && isOnGround)
        {  

            isOnGround = false;
            isJumping = true;
            doubleJumpAllowed = false;

            rigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        else if (isJumping)
        {
            if (!isOnGround && doubleJumpCounter == 0)
                doubleJumpAllowed = true;
            if (input.jumpPressed && doubleJumpAllowed && doubleJumpCounter == 0)
            {
                rigidBody.AddForce(new Vector2(0f, doubleJumpForce), ForceMode2D.Impulse);
                doubleJumpCounter++;
                doubleJumpAllowed = false;
            }
            if (isOnGround)
            {
                isJumping = false;
                doubleJumpAllowed = false;
                doubleJumpCounter = 0;
            }                             
        }
        
        if (rigidBody.velocity.y < maxFallSpeed)
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, maxFallSpeed);
    }
    */
    void Crouch()
    {
        isCrouching = true;

        animator.SetBool("isCrouching", isCrouching);

        // Aplica el cambio de tamaño al agacharse

        bodyCollider.size = colliderCrouchSize;
        bodyCollider.offset = colliderCrouchOffset;
    }


    void StandUp()
    {
        if (isHeadBlocked)
            return;

        isCrouching = false;
        animator.SetBool("isCrouching", isCrouching);

        bodyCollider.size = colliderStandSize;
        bodyCollider.offset = colliderStandOffset;
    }

    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length)
    {
        // Sobrecarga la funcion Raycast usando el layer del suelo y devolviendo el resultado
        return Raycast(offset, rayDirection, length, groundLayer);
    }

    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length, LayerMask mask)
    {
        Vector2 pos = transform.position;

        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDirection, length, mask);

        // Debugar con Raycast
        if (drawDebugRaycast)
        {
            Color color = hit ? Color.red : Color.green;
            Debug.DrawRay(pos + offset, rayDirection * length, color);
        }
        return hit;
    }

    void FlipCharacterDirection()
    {
        direction *= -1;

        transform.Rotate(0f, 180f, 0f);
       
    }
}
    



