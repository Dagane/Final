using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSpikes : MonoBehaviour
{
    //Variables
    private PlayerHealth playerHealth;



    [SerializeField]
    int damage;
    [SerializeField]
    float empuje = 2f;

    private DamageCoolDown damageCool;
    private PlayerMovement playerMove;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Obtener al jugador
            GameObject player = collision.gameObject;

            damageCool = player.GetComponent<DamageCoolDown>();
            playerHealth = player.GetComponent<PlayerHealth>();

            if (damageCool.coolDownTimer == 0)
            {
                //Hacer daño, reiniciar el cooldown y ponerle knockback
                playerHealth.Daño(damage);
                damageCool.coolDownTimer = damageCool.coolDown;
                playerMove.EnemyKnockBack(transform.position.x, empuje);
            }
                                   
        }
    }

   
}
