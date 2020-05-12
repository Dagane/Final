using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    //Variables
    private Rigidbody2D rb2d;
    public PlayerMovement move;
    public Animator anim;
    public float secondSpeed, speed, maxSpeed;
    public int health = 5;
    public CircleCollider2D attackPoint;
    private float stoper = 1f;
    public GameObject player;
    public float look = 1f;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        secondSpeed = speed;
    }

    void Update()
    {
        anim.SetFloat("Speed", speed);
        anim.SetInteger("Health", health);

        //Muerte
        if (health == 0)
        {
            Muerte();
        }

        // Hacia donde mira el enemigo
    }

    private void FixedUpdate() {
        Vector3 fixedSpeed = rb2d.velocity;
        fixedSpeed.x *= 0.75f;
        rb2d.velocity = fixedSpeed;


        //Movimiento del enemigo/Patrullar

        rb2d.AddForce(transform.right * speed * stoper * look);

    }

    //Muerte
    void Muerte()
    {
        rb2d.simulated = false;
        anim.SetBool("Dead", true);
    }

    //Colisiones con el jugador
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            move.SendMessage("EnemyKnockBack",transform.position.x);
        }

    }
    private void OnCollisionExit2D(Collision2D other)
    {
        anim.SetBool("Hit", false);
    }

    //Preparar el ataque
    private void OnTriggerEnter2D(Collider2D other)
    {
        secondSpeed = speed;
        if (other.gameObject.tag == "Player" && health >= 5)
        {
            stoper = 0f;
            anim.SetBool("OnRangeAttack",true);
            LookPlayer();
        }

        if (other.gameObject.tag == "Player" && health < 5)
        {
            EscapePlayer();
        }

        if(other.gameObject.tag == "Weapon")
        {
            health -= 1;
            anim.SetBool("Hit", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            stoper = 1f;
            anim.SetBool("OnRangeAttack", false);
            LookPlayer();
        }
        anim.SetBool("Hit",false);

        if (other.gameObject.tag == "Player" && health < 5)
        {
            EscapePlayer();
        }
    }

    private void LookPlayer()
    {
        look *= Signo(player);

        transform.localScale = new Vector3(1f * look, 1f, 1f);
    }

    private void EscapePlayer()
    {
        look *= Signo(player);

        transform.localScale = new Vector3(-1f * look, 1f, 1f);
    }

    private int Signo (GameObject other)
    {
        if (transform.position.x - other.transform.position.x >= 0)
            return -1;
        else
            return 1;
    }

}


