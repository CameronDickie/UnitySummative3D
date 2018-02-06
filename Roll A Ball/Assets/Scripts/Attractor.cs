using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {
    /*
     * Cameron Dickie
     * December 21st 2017
     * Creates a script to attract two objects with a rigidbody together
     */
    public int limit;

    const float G = 6674f;

    public static List<Attractor> Attractors;

    public Rigidbody rb;
    private void FixedUpdate()
    {
        
        foreach (Attractor attractor in Attractors)
        {
            if (attractor != this && !this.gameObject.CompareTag("Pickups"))
            {
                Attract(attractor); // attracts all objects in the static list
            }
        }
    }

    void OnEnable()
    {
        limit = 250;
        if (Attractors == null)
        {
            Attractors = new List<Attractor>(); //init array if empty
        }
        Attractors.Add(this); // add this attractor to the static list
    }
    void Attract(Attractor objToAttract)
    {
        if(objToAttract == null)
        {
            return;
        }
        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position; // find the direction to attract 
        float distance = direction.magnitude;

        float forceMagnitude = G* (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        if(forceMagnitude> limit) //limit magnitude based off  of a minimum distance, that way the mass doesn't bug out
        {
            forceMagnitude = limit;
        }
        
        Vector3 force = direction.normalized * forceMagnitude; // creating a vector of the force and direction

        if(this.gameObject.CompareTag("Mass") && objToAttract.gameObject.CompareTag("Pickups")) // if the two objects are a mass and a pickup, don't attract
        {
            return; 
        } else { 
            rbToAttract.AddForce(force);
        }
    }
}
