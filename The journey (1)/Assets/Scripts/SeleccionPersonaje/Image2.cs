using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image2 : MonoBehaviour
{
    Color myColor;
    bool select;
    public bool select2;





    void Start()
    {
        myColor = GameObject.Find("Image2").GetComponent<Image>().color;
    }

    public void OnMouseEnter()
    {
        select = true;
        GameObject.Find("Image2").GetComponent<Image>().color = Color.red;
    }

    public void OnMouseExit()
    {
        select = false;
        GameObject.Find("Image2").GetComponent<Image>().color = myColor;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && select == true)
        {
            select2 = true;
        }
    }
}
