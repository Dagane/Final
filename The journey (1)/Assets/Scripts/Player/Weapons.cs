using UnityEngine;
using UnityEngine.UI;

public class Weapons : MonoBehaviour
{   
    [SerializeField]
        GameObject hachas;
    [SerializeField]
        GameObject bulletPrefab;
    [SerializeField]
        Transform bulletSpawner;
    [SerializeField]
        Text municionText;
    
    private Animator anim;
    private AudioSource audioSource;

    [SerializeField]
        float coolDown = 0.5f, coolDownTimer = 0;
    
    public int municion = 3; 
    public int damage = 3; 
    public bool isAttack3 = false;

    public KeyCode attack1;
    public KeyCode attack2;
    public KeyCode attack3;

    private void Awake()
    {
        anim = GetComponentInParent<Animator>();
        audioSource = GetComponentInParent<AudioSource>();
    }

    void Start()
    {
        municionText.text = municion.ToString();
    }

    private void Update()
    {
        if (coolDownTimer > 0)
            coolDownTimer -= Time.deltaTime;
        if (coolDownTimer < 0)
            coolDownTimer = 0;

        //llamo al disparo
        disparoJugador();
    }

    //Disparo
    public void disparoJugador()
    {
        if (coolDownTimer == 0)
        {   
            //ataques del jugador
            if (Input.GetKeyDown(attack1))
            {
                anim.SetTrigger("Attack1");
                SoundManager.PlaySound("lanzaHacha");

                //Reiniciar el coolDown
                coolDownTimer = coolDown;
            }
            else if (Input.GetKeyDown(attack2))
            {
                anim.SetTrigger("Attack2");
                SoundManager.PlaySound("disparoHacha");

                //Reiniciar el coolDown
                coolDownTimer = coolDown;
            }

            if (isAttack3)
            {
                hachas.SetActive(true);

                if (Input.GetKeyDown(attack3) && municion > 0)
                {
                    anim.SetTrigger("Attack3");
                    SoundManager.PlaySound("hachazo");

                    Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
                    //Llama añadir municion pero le manda -1 bala
                    AñadirMunicion(-1);

                    //Reiniciar el coolDown
                    coolDownTimer = coolDown;
                }
            }
        }
    }

    //Añadir municion
    public void AñadirMunicion(int cant)
    {
        //Añade municion y actualiza el texto
        municion += cant;
        municionText.text = municion.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Enemy"))
        {
            //Hacer daño al enemigo 
            other.gameObject.GetComponent<EnemyHealth>().Daño(damage);
        }
    }
}
