using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    //Variables
    private PlayerController controller;
    private Rigidbody2D rb;

    void Start()
    {
        controller = GetComponentInParent<PlayerController>();
        rb = GetComponentInParent<Rigidbody2D>();
    }

    void OnTriggerStay2D(Collider2D ground)
    {
        if (ground.gameObject.tag == "Ground" && rb.velocity.y == 0)
            controller.isGrounded = true;
        else if (ground.gameObject.tag == "PlatformMovil" && rb.velocity.y == 0)
        {
            controller.transform.parent = ground.transform;
            controller.isGrounded = true;
        }
        else if (ground.CompareTag("PuertaSuelo"))
            controller.isGrounded = true;
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Ground")
            controller.isGrounded = false;

        if (other.gameObject.tag == "PlatformMovil")
        {
            controller.transform.parent = null;
            controller.isGrounded = false;
        }
    }

}
