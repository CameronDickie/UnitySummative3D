using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingMassScript : MonoBehaviour {
    /*
     * Cameron Dickie
     * Decemeber 30th 2017
     * Separate Script for masses that shrink when the player is touching it, and explode with pickups
     */
    public Rigidbody rb;
    
    [SerializeField] GameObject player;
    [SerializeField] GameObject pickupPrefab;

    [SerializeField] double Speed;
    [SerializeField] int baseMass;

    Vector3 randomDirection;
    Vector3 scaleSpeed;
    Vector3 deleteScale;

    private void Start()
    {
        baseMass = 15;
        Speed = transform.localScale.x*0.1;
        scaleSpeed = new Vector3((int) Speed, (int) Speed, (int) Speed);
        
    }
    private void LateUpdate()
    {
        //if the mass is less than a certain size, explode with pickup prefabs and delete the object
        if(transform.localScale.x <= 1.5 && transform.localScale.y <= 1.5 && transform.localScale.z <= 1.5)
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject pickup;
                pickup = Instantiate(pickupPrefab, transform.position, transform.rotation); 
                randomDirection = new Vector3(Random.value, Random.value, Random.value);
                Vector3 force = randomDirection.normalized * 700;
                pickup.GetComponent<Rigidbody>().drag = 5;
                pickup.GetComponent<Rigidbody>().AddForce(force);
            }
            
            Destroy(this.gameObject);
            Destroy(this);
        }

        //if the player gets within a certain distance, increase the mass by a multiple of 20, that way the player is certain to hit it
        if (Vector3.Distance(transform.position, player.transform.position) < 40)
        {
            rb.mass = baseMass * 20;
        } else
        {
            rb.mass = baseMass;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        //lower scale if touching player
        if(collision.gameObject.CompareTag("Player"))
        {
            this.transform.localScale -= scaleSpeed * Time.deltaTime;  
        }

    }
}
