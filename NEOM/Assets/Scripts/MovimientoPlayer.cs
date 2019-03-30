using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{

    public bool drawDebugRaycast = true;        //Para dibujar el raycast que comprueba el entorno
    Weapon firePoint;

    [Header("Movement Properties")]
    public float speed = 8f;
    public float maxFallSpeed = -25f;

    [Header("Jump Properties")]
    public float jumpForce = 22.5f;
    public float doubleJumpForce = 10.7f;
    public int doubleJumpCounter = 0;

    [Header("Enviroment Check Properties")]
    public float feetOffset = 0f;
    public float headDistance = 0.5f;
    public float groundDistance = 0.2f;
    public LayerMask groundLayer;

    [Header("Player Status")]
    public bool isOnGround;
    public bool isJumping;
    public bool doubleJumpAllowed;
   

    PlayerInput input;                          //Input recibido
    BoxCollider2D bodyCollider;
    Rigidbody2D rigidBody;

    float playerHeight;

    float originalXScale;
    int direction = 1;


    // Use this for initialization
    void Start()
    {
        groundLayer = LayerMask.GetMask("Default");
        // Cogiendo referencias
        input = GetComponent<PlayerInput>();
        rigidBody = GetComponent<Rigidbody2D>();
        bodyCollider = GetComponent<BoxCollider2D>();
        // Guarda la escala X del sprite
        originalXScale = transform.localScale.x;
        // Guarda la altura del boxCollider
        playerHeight = bodyCollider.size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Comprobar el entorno lanzando rayos desde el player
        PhysicsCheck();

        //Procesar Movimiento
        GroundMovement();
        MidAirMovement();
    }

    void PhysicsCheck()
    {
        isOnGround = false;

        RaycastHit2D underCheck = Raycast(new Vector2(feetOffset, (-playerHeight)-0.3f), Vector2.down, groundDistance);

        if (underCheck)
            isOnGround = true;

    }

    void GroundMovement()
    {
        float xVelocity = speed * input.horizontal;

        if (xVelocity * direction < 0f)
            FlipCharacterDirection();

        rigidBody.velocity = new Vector2(xVelocity, rigidBody.velocity.y);
    }

    void MidAirMovement()
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
        
        Vector3 scale = transform.localScale;
        scale.x = originalXScale * direction;
       

        transform.localScale = scale;
       
    }
}
    



