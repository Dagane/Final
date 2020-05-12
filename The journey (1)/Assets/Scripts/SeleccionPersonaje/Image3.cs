using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image3 : MonoBehaviour
{
    Color myColor;
    bool select;
    public bool select3;





    void Start()
    {
        myColor = GameObject.Find("Image3").GetComponent<Image>().color;
    }

    public void OnMouseEnter()
    {
        select = true;
        GameObject.Find("Image3").GetComponent<Image>().color = Color.red;
    }

    public void OnMouseExit()
    {
        select = false;
        GameObject.Find("Image3").GetComponent<Image>().color = myColor;
    }

 
}
