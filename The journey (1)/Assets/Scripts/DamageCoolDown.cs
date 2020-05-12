using UnityEngine;

public class DamageCoolDown : MonoBehaviour
{
    //Variables
    public float coolDown=2;
    public float coolDownTimer;
   
    void Update()
    {
        if (coolDownTimer > 0)
            coolDownTimer -= Time.deltaTime;
        if (coolDownTimer < 0)
            coolDownTimer = 0;
        
    }

}
