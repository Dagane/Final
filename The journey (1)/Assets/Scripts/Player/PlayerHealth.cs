using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerController cont;
    private Animator anim;
    public Vidas corazones;

    public int maxHealth;

    public int health;

    private bool hasSound = false;

    void Awake()
    {
        cont = GetComponent<PlayerController>();
        anim = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        //Inicializa la vida máxima
        health = maxHealth;
       // healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        //Vida <= 0 llamar muerte
        if (health <= 0)
            Muerte();
    }

    public void Muerte()
    {
        //Para el movimiento
        cont.isDead = true;
        
        if (!hasSound)
        {
            SoundManager.PlaySound("PlyrMuerteWhilelm");
            //Evita que se reproduzca varias veces
            hasSound = true;
        }
       
    }

    public void RellenarVida()
    {
        health = maxHealth;
    }

    public void RecuperarSalud(int amount)
    {
        health += amount;
        if (health > maxHealth)
            health = maxHealth;
    }

    public void Daño(int damage)
    {
        health -= damage;
        
        //Se setea el trigger y se reproduce el sonido
        anim.SetTrigger("Damaged");
        SoundManager.PlaySound("playerDamage");
    }

}