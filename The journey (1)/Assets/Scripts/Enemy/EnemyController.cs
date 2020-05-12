using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyHealth Health;
    private EnemyMovement move;
    private Rigidbody2D rb;
    private DamageCoolDown damageCool;

    public float side, empuje = 2f;
    public int damage;
    public bool isDead = false;
    public bool isScared = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        move = GetComponent<EnemyMovement>();
        damageCool = GetComponent<DamageCoolDown>();
        Health = GetComponent<EnemyHealth>();
    }

    void Start()
    {
        side = 1f;
    }

    void Update()
    {
        //Cambia la escala
        transform.localScale = new Vector3(1f * side, 1f, 1f);

        if (isDead)
            move.isStopped = true;
    }

    //Colisiones con el jugador
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerMovement plMove = other.gameObject.GetComponent<PlayerMovement>();
            plMove.EnemyKnockBack(transform.position.x, empuje);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Weapon" && damageCool.coolDownTimer == 0)
        {
            SoundManager.PlaySound("chop");
            damageCool.coolDownTimer = damageCool.coolDown;
        }
    }
}
