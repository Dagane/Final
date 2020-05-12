using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchAnim : MonoBehaviour
{
    public bool hasActivated = false;

    public Sprite switchOn;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !hasActivated)
        {
            //Cambia el scrip, pone sonido y evita que se repita
            GetComponent<SpriteRenderer>().sprite = switchOn;
            SoundManager.PlaySound("switch");
            hasActivated = true;
        }
    }
}
