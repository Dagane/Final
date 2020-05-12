using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField]
        float speed = 3f;
    [SerializeField]
        AudioClip climbSound;

    public GameObject top;
    private Rigidbody2D rb;
    private new AudioSource audio;

    private bool isClimbing = false;
    
    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetAxis("Vertical") != 0)
            {
                isClimbing = true;

                rb = other.GetComponent<Rigidbody2D>();
                
                //Si es el jugador y está presionando W o S
                if (!other.GetComponent<PlayerController>().isClimbing)
                {
                    //Si no está subiendo, se pone grounded true
                    other.GetComponent<PlayerController>().isClimbing = true;
                    other.GetComponent<PlayerController>().isGrounded = false;
                }
                float dir = Input.GetAxis("Vertical");

                if (isClimbing)
                {
                    //Gravedad del jugador 0 para que no se caiga
                    rb.gravityScale = 0f;
                    rb.velocity = new Vector2(0, speed * dir);
                }

                //Reproduce el sonido de subir escaleras
                if (!audio.isPlaying)
                {
                    audio.clip = climbSound;
                    audio.Play();
                }

                //Base superior de la escalera
                top.SetActive(false);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isClimbing = false;
            //Cuando se sale, se le vuelve a poner la gravedad
            //Se pone climbing false
            //Se vuelve a activar la parte superior de la escalera
            rb = other.GetComponent<Rigidbody2D>();
            rb.gravityScale = 1f;

            other.GetComponent<PlayerController>().isClimbing = false;

            //Parar el sonido
            audio.Stop();

            top.SetActive(true);
        }
    }
}
