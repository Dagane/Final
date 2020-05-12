using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaFlecha : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;

    private PlayerHealth playerHealth;
    private PlayerMovement playerMove;
    private Animator playerAnim;
    private DamageCoolDown damageCool;

    [SerializeField]
    int damage;
    [SerializeField]
    float empuje = 2f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);


    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x==target.x&& transform.position.y==target.y)
        {
            DestroyFlecha();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth = player.GetComponent<PlayerHealth>();
            playerMove = player.GetComponent<PlayerMovement>();
            damageCool = player.GetComponent<DamageCoolDown>();


            playerHealth.Daño(damage);
            damageCool.coolDownTimer = damageCool.coolDown;
            playerMove.EnemyKnockBack(transform.position.x, empuje);
            DestroyFlecha();
        }
    }

    void DestroyFlecha()
    {
        Destroy(gameObject);
    }


}
