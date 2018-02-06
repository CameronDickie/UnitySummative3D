using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    /*
     * Cameron Dickie
     * December 21st 2017
     * Basic Camera Controls (no longer implemented)
     */

    public GameObject player;
    private Vector3 offset;
	// Use this for initialization

	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
