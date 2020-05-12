using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarCanvas : MonoBehaviour
{
    [SerializeField]
    GameObject canvasObject;

    [SerializeField]
    bool activar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (activar)
                //playerInRange = false;
                canvasObject.SetActive(true);
            else
                canvasObject.SetActive(false);

        }
    }

}



