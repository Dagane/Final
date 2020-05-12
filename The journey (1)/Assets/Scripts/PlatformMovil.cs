/*
* Copyright (c) Christian Andrade
* christian.andrade@upb.edu.co
*/

using UnityEngine;

public class PlatformMovil : MonoBehaviour
{
    //Variables
    public Transform target;
    public float speed;

    private Vector3 start, end;


    void Start()
    {
        if(target != null){
            target.parent = null;
            start = transform.position;
            end = target.position;
        }
    }

    void Update()
    {
        
    }

    private void FixedUpdate() {
        if(target != null){
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
        }

        if(transform.position == target.position){
            target.position = (target.position == start) ? end : start;
        }
        
    }

}
