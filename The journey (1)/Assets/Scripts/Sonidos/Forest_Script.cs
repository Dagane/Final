using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest_Script : MonoBehaviour
{

    public bool haSonado=false;
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Suena el ambiente dependiendo donde se encuentra.

    //Bosque

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player" && !haSonado)
        {
            SoundManager.PlaySound("Forest_Ambience");
            haSonado = true;
        }


    }
}
