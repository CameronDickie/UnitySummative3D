using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassScript : MonoBehaviour {

    /*
     * Cameron Dickie
     * December 21st 2017
     * Creates a manager for all masses for the camera to look at
     */
    public GameObject Player;
    public GameObject PlayerTarget;
    public List<Transform> AllTargetMasses;
    private int targetMassNum;


    public GameObject CameraReference;

    MultipleTargetsCamera targetsCamera;
    private void Start()
    {
        //makes a list of all target masses for the camera to look at
        for(int i = 0; i < transform.childCount; i++)
        {
            AllTargetMasses.Add(this.gameObject.transform.GetChild(i));
        }
        targetsCamera = CameraReference.GetComponent<MultipleTargetsCamera>();
        targetMassNum = 0;
        targetsCamera.Target = AllTargetMasses[0];
    }

    private void LateUpdate()
    {
        float dist = Vector3.Distance(Player.transform.position, targetsCamera.Target.transform.position);
        if (dist < targetsCamera.MinCheckDistance) ChangeTarget();
        
    }

    private void ChangeTarget()
    {
        //changes the current target for the camera to refer to 
        if(targetMassNum + 1 < AllTargetMasses.Count) targetMassNum++;
         
        if(AllTargetMasses[targetMassNum] == null)
        {
            targetsCamera.Target = PlayerTarget.transform;
        }
        targetsCamera.Target = AllTargetMasses[targetMassNum];
    }
}

