using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private GameObject player;
    private Transform playerTrans;
    private Rigidbody2D balaRB;
    private float bSpeed = 10;
    private float dir;

    [SerializeField]
    int Damage;

    void Awake()
    {
        balaRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    private void Start()
    {
        playerTrans = player.transform;

        //Dirección del jugador
        dir = playerTrans.localScale.x;

        //Direccion de la bala
        balaRB.velocity = new Vector2(bSpeed * dir, balaRB.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        //para rotar el hacha
        transform.Rotate(new Vector3(0f, 0f, -10f * dir));

        //Destruirla después de 2 seg
        Destroy(gameObject, 2f);
    }

    //Aqui se le hace daño al enemigo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SoundManager.PlaySound("chop");
            collision.gameObject.GetComponent<EnemyHealth>().Daño(Damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Ground")
        {
            //Destruirla al golpear la pared 0 suelo
            SoundManager.PlaySound("chop");
            Destroy(gameObject);
        }
    }
}
