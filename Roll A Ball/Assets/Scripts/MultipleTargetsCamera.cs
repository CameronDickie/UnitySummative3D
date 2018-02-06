using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTargetsCamera : MonoBehaviour {

    /*
      * Cameron Dickie
      * December 21st 2017
      * Looks at the center between the player and the current target
      */

    public GameObject Player;
    public Transform Target { set; get; }

    public Vector3 center;

    public float MinCheckDistance { set; get; }

    private void Start()
    {
        MinCheckDistance = 40;
    }
    private void LateUpdate()
    {
        if(Target == null)
        {
            //look only at player
            Target = Player.transform;
        }
        else { 
        center = (Target.position - Player.transform.position) / 2.0f + Player.transform.position;
        transform.LookAt(center);
        }

    }
    
}
