using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotauroDead : MonoBehaviour
{
    private EnemyMovement move;
    private EnemyController cont;

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
        
    }

    void Start()
    {
        //Inicializa la vida máxima
        health = healthMax;
    }

    void Update()
    {
        //Vida <= 0 llamar muerte
        if (health <= 0)
            Muerte();
    }

    void Muerte()
    {
        //Para el movimiento
        move.isStopped = true;
        cont.isDead = true;

        

        if (!hasSound)
        {
            //Evita que se reproduzca muchas veces
            SoundManager.PlaySound(muerteSonido);
            hasSound = true;
        }

        Destroy(gameObject);
        //Spawnear el pickUp
        //OnDead(0);
        drop.Drop();
    }

    public void Daño(int damage)
    {
        //Quita vida 
        health -= damage;

        SoundManager.PlaySound(dañoSonido);
        
    }
}
