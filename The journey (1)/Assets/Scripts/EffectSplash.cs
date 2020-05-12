using UnityEngine;

public class EffectSplash : MonoBehaviour
{
    //Variables
    public Animator anim;
    private bool hit = false;

    void Update()
    {

        anim.SetBool("Enemy Hitting", hit);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy")
            hit = true;
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy")
            hit = false;
    }


}
