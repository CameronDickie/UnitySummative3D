using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuScript : MonoBehaviour {

    // Use this for initialization

    Rigidbody rb;
    Vector3 dir;
    public float forceMag = 400;
	void Start () {
        rb = GetComponent<Rigidbody>();
        dir = new Vector3(0, 1, 0);
        rb.AddForce(dir * forceMag);
    }
	/*
    public void SetProjectileForceMag(float _forceMag)
    {
        forceMag = _forceMag;
        rb.AddForce(dir * forceMag);
    }

	// Update is called once per frame
	void Update () {
		
	}
    */
}
