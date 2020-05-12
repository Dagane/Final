using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondPlayerSpawner : MonoBehaviour
{

    public GameObject player2Spawn;
    public Text perdos;



    void Update()
    {


        if (player2Spawn != null)
        {

            if (Input.GetKeyDown(KeyCode.P))
            {
                SoundManager.PlaySound("spawn");
                Instantiate(player2Spawn, transform.position, Quaternion.identity);
                perdos.enabled = false;
            }


        }
       
    }
}
