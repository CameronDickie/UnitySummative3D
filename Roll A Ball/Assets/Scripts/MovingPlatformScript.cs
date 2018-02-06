using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour {
    /*
     * Cameron Dickie
     * January 9th
     * Simplistic movement for a platform (buggy with forces)
     */
    public Transform Player;
    public GameObject MovingMass;
    public GameObject MainCameraReference;
    public MultipleTargetsCamera Camera;
    public Vector3 dir;
    public int speed;
    private bool isMoving;

    // Use this for initialization
    void Start () {
        isMoving = false;
        Camera = MainCameraReference.GetComponent<MultipleTargetsCamera>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isMoving)
        {
            transform.Translate(dir*Time.deltaTime*speed);
            Camera.Target = MovingMass.transform;
            MovingMass.GetComponent<Rigidbody>().mass = 9;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isMoving = true;
        }
    }

    
}
