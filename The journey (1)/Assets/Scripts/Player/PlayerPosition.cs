using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private GameMaster gm;
    private int health;
    private int hachas;

    void Awake()
    {
        gm = GameObject.FindWithTag("GM").GetComponent<GameMaster>();
        health = GetComponent<PlayerHealth>().health;
        hachas = GetComponentInChildren<Weapons>().municion;
    }

    void Start()
    {
        transform.position = gm.lastCheckpointPos;
        health = gm.health;
        hachas = gm.hachas;
    }
}
