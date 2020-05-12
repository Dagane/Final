using UnityEngine;

public class SkeletonAxe : MonoBehaviour
{
    //Variables
    private PlayerHealth playerHealth;
    private PlayerMovement playerMove;
    private Animator playerAnim;
    private DamageCoolDown damageCool;

    [SerializeField]
    int damage;
    [SerializeField]
    float empuje = 2f;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            //Obtener al jugador
            GameObject player = other.gameObject;
            
            playerHealth = player.GetComponent<PlayerHealth>();
            playerMove = player.GetComponent<PlayerMovement>();
            damageCool = player.GetComponent<DamageCoolDown>();
            playerAnim = player.GetComponent<Animator>();

            if (damageCool.coolDownTimer == 0 )
            {
                //Hacer daño, reiniciar el cooldown y ponerle knockback
                playerHealth.Daño(damage);
                damageCool.coolDownTimer = damageCool.coolDown;
                playerMove.EnemyKnockBack(transform.position.x, empuje);
            }
        }        
    }

}
