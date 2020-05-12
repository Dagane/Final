using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Troncos : MonoBehaviour
{
    [SerializeField]
        Text ScoreTronco;
        
    public int cantidad = 0;

    // Start is called before the first frame update
    void Start()
    {
        ScoreTronco.text = cantidad.ToString();    
    }

    public void AñadirTroncos(int cant)
    {
        //Sumarle la cantidad de troncos
        cantidad += cant;
        ScoreTronco.text = cantidad.ToString();
    }

}
