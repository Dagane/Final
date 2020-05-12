using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    private PlayerController controller;
    private Rigidbody2D rb;

    [SerializeField]
    float jumpPower = 6.5f, runSpeed = 40f, maxSpeed = 5f, jumpTimes = 0, fallMultiplier = 2.5f, lowJumpMultiplier = 2f;

    //[SerializeField] AudioClip[] clips;

    public int maxJumpTimes = 1;

    float horizontalMove = 0f;
    
    bool isJumping = false;

    //Disparo
    public Transform bulletSpawner;
    public GameObject bulletPrefab;



    //Ataques
    private Animator anim;
    [SerializeField]
    bool attack1, attack2, attack3;


    //Sonido
    private AudioSource audioSource;

    //Controles movimiento

    public KeyCode jump;
    public KeyCode left;
    public KeyCode right;





    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
        audioSource = GetComponentInParent<AudioSource>();
        //InvokeRepeating("PlaySound", 0.0f, 0.5f);
    }

    void Update()
    {
        // Detectar del salto, SALTAR
        if (controller.isGrounded)
            jumpTimes = 0;

        if (Input.GetKeyDown(jump) && jumpTimes < maxJumpTimes)
        {
            SoundManager.PlaySound("jump");
            jumpTimes += 1;
            
            isJumping = true;
            //if(!audioSource.isPlaying) audioSource.PlayOneShot(clips[0]);
        }
        if (Input.GetKey(left))
        {
            horizontalMove = -1f * runSpeed;
        }
        else if (Input.GetKey(right))
        {
            horizontalMove = 1f * runSpeed;
        }
        else
        {
            horizontalMove = 0f;
        }
       

        // Cambiar hacia donde mira el personaje

        if (!controller.isClimbing)
        {
           // audioSource.PlayOneShot(clips[1]);
            if (horizontalMove > 0)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }

            if (horizontalMove < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }

    }

    void FixedUpdate()
    {
        // Simulacion de Friccion

        Vector3 fixedVelocity = rb.velocity;
        fixedVelocity.x *= 0.75f;
        if (controller.isGrounded)
            rb.velocity = fixedVelocity;


        //Mover el personaje

        rb.AddForce(Vector2.right * runSpeed * horizontalMove);
        float limitedSpeed = Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed);
        rb.velocity = new Vector2(limitedSpeed, rb.velocity.y);

        //Dar la orden se saltar

        if (isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJumping = false;
        }

        //Mejor salto
        if (!controller.isClimbing)
        {
            if (rb.velocity.y < 0)
                rb.gravityScale = fallMultiplier;
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
                rb.gravityScale = lowJumpMultiplier;
            else
                rb.gravityScale = 1f;
        }

    }

    void PlaySound()
    {
        if (Input.GetButton("Horizontal") && controller.isGrounded)
        {
            SoundManager.PlaySound("camina");
        }
    }

    public void EnemyKnockBack(float enemyPosX, float empuje)
    {
        isJumping = true;
        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rb.AddForce(Vector2.left * side * empuje, ForceMode2D.Impulse);
    }
}

