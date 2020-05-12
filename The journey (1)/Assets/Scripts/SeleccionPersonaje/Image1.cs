using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image1 : MonoBehaviour
{
    
    Color myColor;
    bool select;
    public bool select1;





    void Start()
    {
        myColor = GameObject.Find("Image1").GetComponent<Image>().color;
    }

    public void OnMouseEnter()
    {
        select = true;
        GameObject.Find("Image1").GetComponent<Image>().color = Color.red;
    }

    public void OnMouseExit()
    {
        select = false;
        GameObject.Find("Image1").GetComponent<Image>().color = myColor;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && select==true)
        {
            select1 = true;  
        }
    }
}





