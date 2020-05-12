using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour

{
    private Rigidbody2D rb;
    private Animator anim;
    private Weapons hacha;

    public GameObject pigKey;

    public bool isGrounded;
    public bool isClimbing = false;
    public bool isDead = false;
    public bool key = false;

    public bool isInForest = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        hacha = GetComponentInChildren<Weapons>();
    }

    void Update()
    {
        //Control de Animaciones
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("Grounded", isGrounded);
        anim.SetFloat("Potencia de Salto", rb.velocity.y);
        anim.SetBool("isDead", isDead);
        anim.SetBool("isClimbing", isClimbing);

        //Velocidad animación en escalera
        if (isClimbing)
        {
            if (Input.GetAxis("Vertical") == 0)
                anim.speed = 0f;
            else
                anim.speed = 1f;

        }
        else
            anim.speed = 1f;

        //Si está muerto llama Dead
        if (isDead)
            Muerte();
    }

    void Muerte()
    {
        //Evita que se mueva
        rb.simulated = false;
    }

}


//Para detectar colisiones con los Triggers, palancas, props, etc.
//private void OnTriggerEnter2D(Collider2D collision){
//    if(collision.gameObject.CompareTag("Player")){
//animator.SetBool("Pressed",true)
//}
//}



