using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;

public class PlayerController : MonoBehaviour {

    /*
     * Cameron Dickie
     * December 21st 2017
     * Simplistic Player Controls along with controlling other scripts through keypresses
     */
    public Rigidbody rb;
    public float speed;
    private int count;
    public bool isGrounded;
    public static List<GameObject> pickups;
    public TextMeshProUGUI countText;
    public Vector3 VelLimit;
    public GameObject UI;
    
    private void Start()
    {
        pickups = new List<GameObject>();
        rb = GetComponent<Rigidbody>();
        count = 0; 
        SetCountText();

    }
    private void FixedUpdate()
    {
        CheckControls(); //checks for input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (isGrounded)
        {
            rb.AddForce(movement * speed); //if player is touching ground you can move
        }
        limitVelocity();

        if(moveHorizontal > 0 || moveVertical > 0)
        {
            if (Camera.main.fieldOfView < 75) Camera.main.fieldOfView += 0.1f;
        } else
        {
            if(Camera.main.fieldOfView > 60)Camera.main.fieldOfView -= 0.1f;
        }
        
        
    }

    private void limitVelocity()
    {
        //limits the velocity within the given value, so that the player does not pass through the ground when traveling fast enough.
        if (rb.velocity.x > VelLimit.x)
        {
            rb.velocity = new Vector3(VelLimit.x, rb.velocity.y, rb.velocity.z);
        }
        if (rb.velocity.y > VelLimit.y)
        {
            rb.velocity = new Vector3(rb.velocity.x, VelLimit.y, rb.velocity.z);
        }
        if(rb.velocity.z > VelLimit.z)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, VelLimit.z);
        }
    }

    private void CheckControls()
    {
        if(Input.GetKeyDown("space") && isGrounded)
        {
            Vector3 jump = new Vector3(0, 40f, 0);
            rb.AddForce(jump * speed);
            isGrounded = false;
        }
        if(Input.GetKeyDown("f"))
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //checks if the player is grounded
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Mass"))
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }

        if(collision.gameObject.CompareTag("Mass") && !collision.gameObject.name.Contains("Shrinking Asteroid"))
        {
            //gameover
            UI.GetComponent<PauseScript>().GameOver();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickups")) //add pickup
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
    private void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        
    }
}
