using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPalanca : MonoBehaviour
{
    [SerializeField]
    Transform trans;
    Collider2D[] A;

    void Start()
    {
        A = trans.GetComponents<Collider2D>();
        foreach (var item in A)
        {
            item.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        transform.localScale = new Vector3(-1, 1, 1);
        foreach (var item in A)
        {
            item.enabled = true;
        }
    }
}
