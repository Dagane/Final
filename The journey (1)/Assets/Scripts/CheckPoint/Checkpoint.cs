using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;
    private Animator anim;

    [SerializeField]
        GameObject dialogBox;  // referencia el cuadro de texto que ira en los carteles
    [SerializeField]
        Text dialogText;
    [SerializeField]
        int cant;
    [SerializeField]
        string dialogNotActive = "Presiona E para activar hoguera, necesitas 3 troncos"; // referencia el dialogo
    [SerializeField]
        string dialogActive = "Presiona E para activar hoguera"; // referencia el dialogo

    private bool isOn = false;

    void Awake()
    {
        gm = GameObject.FindWithTag("GM").GetComponent<GameMaster>();
        anim = GetComponentInChildren<Animator>();
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        //Si está el jugador 
        if (other.CompareTag("Player"))
        {
            //Si está apagada se pone el dialogo
            if (!isOn)
            {
                dialogBox.SetActive(true);
                dialogText.text = dialogNotActive;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    //Si tiene los troncos suficientes
                    if (other.gameObject.GetComponent<Troncos>().cantidad >= cant)
                    {
                        //Restarle los troncos que gastó
                        other.gameObject.GetComponent<Troncos>().AñadirTroncos(-cant);
                        StartCoroutine(SetAnim(other.gameObject));
                    }
                    else
                        dialogText.text = "No tienes los troncos suficientes";
                }
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialogActive;

                if (Input.GetKeyDown(KeyCode.E))
                {

                }
            }
        }
    }

    IEnumerator SetAnim(GameObject player)
    {
        //Pone la anim de lanzar tronco
        player.GetComponent<Animator>().SetTrigger("Throw");
        isOn = true;
        SaveAtributos(player);
        //Espera 1.5 seg y pone la anim de encender
        yield return new WaitForSeconds(1.5f);
        anim.SetTrigger("isOn");
        dialogText.text = "Checkpoint Activado";
        yield return new WaitForSeconds(1.5f);
        dialogBox.SetActive(false);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        //Si se va, se apaga el dialogo
        if (other.CompareTag("Player"))
            dialogBox.SetActive(false);
    }

    void SaveAtributos(GameObject player)
    {
        gm.lastCheckpointPos = transform.position;
        gm.health = player.GetComponent<PlayerHealth>().health;
        gm.hachas = player.GetComponentInChildren<Weapons>().municion;
    }
}
