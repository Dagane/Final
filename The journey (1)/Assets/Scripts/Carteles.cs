using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carteles : MonoBehaviour
{
    [SerializeField]
        GameObject dialogBox;  // referencia el cuadro de texto que ira en los carteles
    [SerializeField]
        Text dialogText;
    [SerializeField]
        string dialog; // referencia el dialogo

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //layerInRange = true;
            dialogBox.SetActive(true);
            dialogText.text = dialog;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //playerInRange = false;
            dialogBox.SetActive(false);
        }
    }

    /*private void OnTriggerStay2D(Collider2D other)
    {

            if  (playerInRange)
            {
                if (dialogBox.activeInHierarchy)
                {
                    dialogBox.SetActive(false);
                }
                else
                {
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                }
            }
        
    }*/
}
