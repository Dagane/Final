using UnityEngine;

public class SkeletonAttack : MonoBehaviour
{
    //Variables
    Animator anim;
    private EnemyMovement move;
    private new AudioSource audio;

    void Awake()
    {
        move = GetComponentInParent<EnemyMovement>();
        anim = GetComponentInParent<Animator>();
        audio = GetComponentInParent<AudioSource>();
    }

    //Si está en rango reproduce "Attack"
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            move.isStopped = true;
            anim.SetTrigger("Attack");
            //SoundManager.PlaySound("esqueletoAttack");
        }
    }

    //Si el jugador se va, vuelve a caminar
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
            move.isStopped = false;
    }

}


