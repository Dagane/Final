using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeleccionPersonaje : MonoBehaviour
{
    Image1 image1;
    Image2 image2;
    Image3 image3;


    
    public bool seleccion1 = false;
    
    public bool seleccion2 = false;
    
    public bool seleccion3 = false;



    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       /* if (image1.select1 == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (image2.select2 == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (image3.select3 == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }*/
    }
    public void PlayGameWhitSelect1()
    {
        seleccion1 = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }
    
     
public void PlayGameWhitSelect2()
    {
        seleccion2 = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void PlayGameWhitSelect3()
    {
        seleccion3 = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        
    }
    public void QuitGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
