using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoPlayer : MonoBehaviour
{

    public Animator animator;
    public bool drawDebugRaycast = true;        //Para dibujar el raycast que comprueba el entorno
    Weapon firePoint;

    public bool pause = false;


    [Header("Movement Properties")]
    private float xVelocity;
    public float speed = 8f;
    public float crouchSpeedDivisor = 3f;
    public float maxFallSpeed = -25f;
    public float slideImpulse = 500.0f;
    
    [Header("Enviroment Check Properties")]
    public float feetOffset = 0f;
    public float headDistance = 0.3f;
    public float groundDistance = 0.2f;
    public LayerMask groundLayer;

    [Header("Player Status")]
    public bool isOnGround;
    public bool isJumping;
    public bool doubleJumpAllowed;
    public bool isCrouching;
    public bool isHeadBlocked;
    public bool isSliding;
   

    PlayerInput input;                          //Input recibido
    CapsuleCollider2D bodyCollider;
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
        bodyCollider = GetComponent<CapsuleCollider2D>();
        // Guarda la altura del boxCollider
        playerHeight = bodyCollider.size.y;

        // Guarda la size y offset inicial del collider
        colliderStandSize = bodyCollider.size;
        colliderStandOffset = bodyCollider.offset;

        // Calcula la altura y el offset al estar agachado
        colliderCrouchSize = new Vector2(bodyCollider.size.x, playerHeight / 2.0f);
        colliderCrouchOffset = new Vector2(bodyCollider.offset.x, bodyCollider.offset.y / 2.0f);

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (!pause)
                pause = true;
            else
                pause = false;
        }


        if (!pause)
        {

            // Comprobar el entorno lanzando rayos desde el player
            PhysicsCheck();

            //Procesar Movimiento
            GroundMovement();


            if (input.reset)
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
                Player.health = 100;
            }
        }
    }

    void PhysicsCheck()
    {
        isOnGround = false;
        isHeadBlocked = false;

        RaycastHit2D underCheck = Raycast(new Vector2(feetOffset, (-playerHeight)-0.3f), Vector2.down, groundDistance);

        if (underCheck)
            isOnGround = true;

        // Raycast para comprobar la si la cabeza está bloqueada

        RaycastHit2D headCheck = Raycast(new Vector2(0f, bodyCollider.size.y * 2.4f), Vector2.up, headDistance);

        if (headCheck)
        {
            isHeadBlocked = true;
            
        }

    }

    void GroundMovement()
    {
        xVelocity = speed * input.horizontal;

        if (input.crouchPressed && !isCrouching && isOnGround && Mathf.Abs(xVelocity) > 0.1f)
        {
            Slide();
        }
        else if (input.crouchHeld && !isCrouching && isOnGround)
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
        

        animator.SetFloat("Speed", Mathf.Abs(xVelocity));

        if (xVelocity * direction < 0f)
            FlipCharacterDirection();

        if (isCrouching)
            xVelocity /= crouchSpeedDivisor;

        rigidBody.velocity = new Vector2(xVelocity, rigidBody.velocity.y);
    }

    
    void Crouch()
    {
        isCrouching = true;

        animator.SetBool("isCrouching", isCrouching);

        // Aplica el cambio de tamaño al agacharse

        bodyCollider.size = colliderCrouchSize;
        bodyCollider.offset = colliderCrouchOffset;
    }

    void Slide()
    {
        isCrouching = false;

        bodyCollider.size = colliderCrouchSize;
        bodyCollider.offset = colliderCrouchOffset;

        Vector2 fuerzaDeslizado = new Vector2(slideImpulse*2, 0);

        rigidBody.AddForce(fuerzaDeslizado, ForceMode2D.Impulse);
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
    



