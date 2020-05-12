using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    private EnemyController cont;
    private bool isDead = false;

    void Awake()
    {
        cont = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        isDead = cont.isDead;

        if (isDead)
        {
            Destroy(gameObject);
        }
    }
}
