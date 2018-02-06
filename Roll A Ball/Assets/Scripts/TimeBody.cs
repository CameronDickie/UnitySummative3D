using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour {
    /*
     * Cameron Dickie
     * January 11th 2018
     * Script to manage all previous positions within a 5 second time period, giving the player the option to rewind time if they make a mistake
     */
    public bool isRewinding = false;

    private PlayerController playerController;
    Rigidbody rb;

    List<PointInTime> pointsInTime;

	// Use this for initialization
	void Start () {
        pointsInTime = new List<PointInTime>(); // script to manage rotation and position to return to
        rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown("r"))
        {
            StartRewind();
        }
        if(Input.GetKeyUp("r"))
        {
            StopRewind();
        }
	}
    private void FixedUpdate()
    {
        
        if (isRewinding)
        {
            Rewind();
        } else
        {
            //record info
            Record();
        }
    }
    private void Record()
    {
        //if there are more points in time than the list can hold in 5 seconds, remove the previous position
        if(pointsInTime.Count > Mathf.Round ((1f/Time.fixedDeltaTime) * 5))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }
        //add newest position
        pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
      

    }
    private void Rewind()
    {
        //if the list is greater than 0, set current position to the last known point in time and remove it from the list
        if (pointsInTime.Count > 0) {
            
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        }
    }
    public void StartRewind()
    {
        //makes the object kinematic during rewind
        rb.isKinematic = true;
        isRewinding = true;
    }

    public void StopRewind()
    {
        //turns off rewinding
        rb.isKinematic = false;
        isRewinding = false;
    }
}
