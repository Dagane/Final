using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAttack : MonoBehaviour
{

    //Variables

    [SerializeField]
    private Animator anim;
    public GameObject flecha;
    private float cooldown;
    public float startShooting;
    public Transform flechaSpawn;

    //Si está en rango reproduce "Attack"
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            anim.SetTrigger("Attack");

            if (cooldown <= 0)
            {
                Instantiate(flecha, flechaSpawn.position, flechaSpawn.rotation);
                cooldown = startShooting;
            }
            else
            {
                cooldown -= Time.deltaTime;
            }
        }
    }



   
}
