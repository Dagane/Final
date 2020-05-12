using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float maxSpeed;
    
    [HideInInspector]
    public bool isStopped = false;
    
    private Rigidbody2D rb;
    
    private float speed;
    private float side;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        side = GetComponent<EnemyController>().side;
    }

    void Start()
    {
        speed = maxSpeed;
    }

    void Update()
    {
        side = GetComponent<EnemyController>().side;
    }

    void FixedUpdate()
    {
    
        if (!isStopped)
        {
            //Movimiento al patrullar

            /* Vector3 fixedVelocity = rb.velocity;
            fixedVelocity.x *= 0.75f;
            //if (controller.isGrounded)
            rb.velocity = fixedVelocity; */
        
            //Mover el personaje

            //rb.AddForce(Vector2.right * speed * side);
            //float limitedSpeed = Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed);
            //rb.velocity = new Vector2(limitedSpeed, rb.velocity.y);
            
            if (side < 0)
            {
                speed = -Mathf.Abs(speed);
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                speed = Mathf.Abs(speed);
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
        }
        else
            //Si isStopped == true, se para el enemigo
            rb.velocity = new Vector2(0f, 0f);
    }

}