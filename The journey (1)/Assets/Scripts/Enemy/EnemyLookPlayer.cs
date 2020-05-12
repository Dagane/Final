using UnityEngine;

public class EnemyLookPlayer : MonoBehaviour
{
    private EnemyController cont;
    private GameObject player;
    private int health;

    [SerializeField]
    int minHealth;

    private bool isRange = false;

    void Awake()
    {
        cont = GetComponentInParent<EnemyController>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Mathf.Abs(player.transform.position.x - transform.position.x) < 5f)
            isRange = true;
        else
            isRange = false;

        if (isRange && health <= minHealth)
            cont.isScared = true;
        else
            cont.isScared = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Obtener la vida del enemigo
            health = GetComponentInParent<EnemyHealth>().health;
            
            //Si la vida es menor o igual a la vida mínima, escapa del jugador
            if (health <= minHealth)
                EscapePlayer(other.gameObject);
            else
                LookPlayer(other.gameObject);
        }
    }

    public void LookPlayer(GameObject player)
    {
        //Side retorna 1, -1
        float side = Mathf.Sign(player.transform.position.x - transform.position.x);
        cont.side = side;
    }

    public void EscapePlayer(GameObject player)
    {
        //Se va en dirección contraria
        float side = Mathf.Sign(player.transform.position.x - transform.position.x);
        cont.side = -side;
   }
}