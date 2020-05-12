using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
        Animator anim;
    [SerializeField]
        BoxCollider2D coll2D;
    [SerializeField]
        GameObject key;

    private bool hasSound = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            bool haveKey = key.GetComponent<switchAnim>().hasActivated;

            if (haveKey && !hasSound)
            {
                SoundManager.PlaySound("door");
                anim.SetBool("Key", true);
                coll2D.enabled = false;
                hasSound = true;
            }
        }
    }
}
