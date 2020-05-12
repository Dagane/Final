/*
* Copyright (c) Christian Andrade
* christian.andrade@upb.edu.co
*/

using UnityEngine;

public class DrawPlatformLine : MonoBehaviour
{
    //Variables
    public Transform from;
    public Transform to;

    private void OnDrawGizmosSelected() {
        if(from != null && to != null){
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(from.position, to.position);
            Gizmos.DrawSphere(from.position, 0.15f);
            Gizmos.DrawSphere(to.position, 0.15f);
        }
    }

}
