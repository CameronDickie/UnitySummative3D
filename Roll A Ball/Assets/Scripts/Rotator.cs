using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    /*
     * Cameron Dickie
     * December 21st 2017
     * class to rotate object based on speed
     */
    public float speed;
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime * speed);
	}
}
