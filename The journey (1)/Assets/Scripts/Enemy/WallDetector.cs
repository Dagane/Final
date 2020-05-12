using UnityEngine;

public class WallDetector : MonoBehaviour
{
    //Variables
    EnemyController cont;

    void Awake()
    {
        cont = GetComponentInParent<EnemyController>();
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Ground")
        {
            if (!cont.isScared)
            {
                //Flipear al enemigo
                cont.side *= -1;
            }
        }
    }
}


