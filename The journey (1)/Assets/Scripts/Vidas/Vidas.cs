using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vidas : MonoBehaviour
{
    public Sprite[] corazones;
    public PlayerHealth vida;

    private Image corazon;

    void Awake()
    {
    	corazon = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        corazon.sprite = corazones[vida.health];
    }

}
