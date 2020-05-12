using UnityEngine;

public class PickUp : MonoBehaviour
{
    //Serializar la cantidad de municion que da
    private int amount;

    [SerializeField]
    int min = 1, max = 3;

    void Start()
    {
        amount = Random.Range(min, max + 1);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Reproduce sonido
            SoundManager.PlaySound("PowUp");

            if (gameObject.CompareTag("Hacha"))
            {
                //Toma el script weapons del jugador y le manda la cantidad de municion
                other.gameObject.GetComponentInChildren<Weapons>().AñadirMunicion(amount);
            }
            else if (gameObject.CompareTag("Tronco"))
            {
                //Toma el script weapons del jugador y le manda la cantidad de municion
                other.gameObject.GetComponent<Troncos>().AñadirTroncos(amount);
            }
            else if (gameObject.CompareTag("Key2"))
           {
                other.gameObject.GetComponent<PlayerController>().key = true;
           }

            else if (gameObject.CompareTag("VidaManzana"))
            {
                other.gameObject.GetComponent<PlayerHealth>().RecuperarSalud(amount);
            }


            Destroy(gameObject);
        }
    }
}