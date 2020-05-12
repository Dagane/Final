using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidarPersonaje : MonoBehaviour
{
    SeleccionPersonaje sP;
    public GameObject femaleCutter;
    public GameObject playerOne;

   

    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sP.seleccion1==true)
        {
            femaleCutter.SetActive(true);
        }
        else { femaleCutter.SetActive(false); }

    }

}
