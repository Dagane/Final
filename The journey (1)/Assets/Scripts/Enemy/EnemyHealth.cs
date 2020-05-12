using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour
{
    private EnemyMovement move; 
    private EnemyController cont;
    private Animator anim;
    private EnemyDrop drop;

    //public Action<int> OnDead;
    
    [SerializeField]
        int healthMax;

    [SerializeField]
        string muerteSonido, dañoSonido;

    public int health;

    private bool hasSound = false;

    void Awake()
    {
        move = GetComponent<EnemyMovement>();
        cont = GetComponent<EnemyController>();
        anim = GetComponentInChildren<Animator>();
        drop = GetComponent<EnemyDrop>();
    }

    void Start()
    {
        //Inicializa la vida máxima
        health = healthMax;
    }

    void Update()
    {
        //Vida <= 0 llamar muerte
        if (health <= 0 )
            Muerte();
    }

    void Muerte() 
    {
        //Para el movimiento
        move.isStopped = true;
        cont.isDead = true;

        //Reproduce la muerte
        anim.SetBool("isDead", true);

        if (!hasSound)
        {        
            //Evita que se reproduzca muchas veces
            SoundManager.PlaySound("muerteEnemy");
            hasSound = true;
        }
        
        //Spawnear el pickUp
        //OnDead(0);
        drop.Drop();
    }

    public void Daño(int damage)
    {
        //Quita vida 
        health -= damage;
        
        SoundManager.PlaySound(dañoSonido);
        //Reproduce "Hit"
        anim.SetTrigger("Hit");
    }

}