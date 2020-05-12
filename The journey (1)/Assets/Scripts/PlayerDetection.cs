/*
* Copyright (c) Christian Andrade
* christian.andrade@upb.edu.co
*/

using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    //Variables
    public Animator anim;
    public GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            //Se pone en estado de alterta
            anim.SetTrigger("JugadorDetectado");
            //Persigue al jugador
            SendMessage("PlayerFollow", player.transform.position.x);
            //Aumenta su velocidad
            //Huye de el cuando tiene poca vida
        }
    }
    private void PlayerFollow(float playerPosX){
        float side = Mathf.Sign(playerPosX - transform.position.x);
    }

}
