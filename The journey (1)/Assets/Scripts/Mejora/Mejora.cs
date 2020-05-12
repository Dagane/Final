using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mejora : MonoBehaviour
{
    [SerializeField]
        GameObject dialogBox;  // referencia el cuadro de texto que ira en los carteles
    [SerializeField]
        Text dialogText;
    [SerializeField]
        string mejora; //Nombre del atributo a mejorar (salto, vida, )
    [SerializeField]
        int cant;
    [SerializeField]
        string dialog; // referencia el dialogo
    [SerializeField]
        string dialogMejorado; // referencia el dialogo después de mejorar

    private bool isOn = false;
    
    public void OnTriggerStay2D(Collider2D other)
    {
        //Si está el jugador 
        if (other.CompareTag("Player"))
        {
            //Si está apagada se pone el dialogo
            if (!isOn)
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            
                //Si está apagada y presiona E se guardan los atributos
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //Si tiene los troncos suficientes
                    if (other.gameObject.GetComponent<Troncos>().cantidad >= cant)
                    {
                        StartCoroutine(SetAnim(other.gameObject));
                        //Restarle los troncos que gastó
                        other.gameObject.GetComponent<Troncos>().AñadirTroncos(-cant); 
                    }
                    else
                        dialogText.text = "No tiene los troncos suficientes";
                }
            }
        }
    }

    IEnumerator SetAnim(GameObject player)
    {
        //Pone la anim de lanzar tronco
        player.GetComponent<Animator>().SetTrigger("Cut");
        isOn = true;
        CambiarEstadisticas(player);

        //Espera 0.7 seg y pone el sonido
        yield return new WaitForSeconds(0.7f);
        SoundManager.PlaySound("chop");
        dialogText.text = dialogMejorado;
        yield return new WaitForSeconds(2f);
        dialogBox.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Si se va, se apaga el dialogo
        if (other.CompareTag("Player"))
            dialogBox.SetActive(false);
    }

    void CambiarEstadisticas(GameObject player)
    {
        switch (mejora)
        {
            case "vida":
                //Suma 2 a la vida (un corazon) y se la rellena
                player.GetComponent<PlayerHealth>().maxHealth += 2;
                player.GetComponent<PlayerHealth>().RellenarVida();
                break;
            case "daño":
                //Se aumenta el daño
                player.GetComponentInChildren<Weapons>().damage += 1;
                break;
            case "ataque":
                //Se desbloquea el ataque de lanzar
                player.GetComponentInChildren<Weapons>().isAttack3 = true;
                break;
            default:
                break;
        }
    }
}
