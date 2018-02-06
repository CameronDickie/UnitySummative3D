using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour {

    public GameObject Text;
    float time = 5f;
    /*
    * Cameron Dickie
    * January 22nd 2018
    * Invisible Trigger to show specific text
    */
    private void Start()
    {
        Text.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ran");
        Text.SetActive(true);
    }

    private void FixedUpdate()
    {
        if(Text.activeInHierarchy) { 
            time -= 1f * Time.deltaTime;
            if(time <= 0)
            {
                Text.SetActive(false);
                time = 5;
            }
        }
    }
}
