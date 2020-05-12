/*
* Copyright (c) Christian Andrade
* christian.andrade@upb.edu.co
*/

using UnityEngine;

public class Timer : MonoBehaviour
{
    //Variables
    public float time, timeCounter;


    void Update()
    {
        if(time > 0){
            time -= Time.deltaTime;
        }
        if(time <= 0){
            time = timeCounter;
        }

        Debug.Log(time);
        
    }

}
