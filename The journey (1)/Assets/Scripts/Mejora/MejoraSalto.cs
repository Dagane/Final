using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejoraSalto : MonoBehaviour
{
    private bool hasMejorado = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasMejorado)
        {
           if( other.GetComponent<PlayerMovement>().maxJumpTimes <2)
            {
                other.GetComponent<PlayerMovement>().maxJumpTimes += 1;
                hasMejorado = true;
            }
            
        }
    }
}
