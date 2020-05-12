using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotauroAttack : MonoBehaviour
{

    //Variables

    [SerializeField]
    private Animator anim;
    [SerializeField]
    private EnemyMovement move;


    /*void Awake()
    {
        anim = GetComponent<Animator>();
        move = GetComponent<EnemyMovement>();
    }*/

    //Si está en rango reproduce "Attack"
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            move.isStopped = true;
            anim.SetTrigger("Attack");
        }
    }

    //Si el jugador se va, vuelve a caminar
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            move.isStopped = false;
            
        }
            
    }
}
