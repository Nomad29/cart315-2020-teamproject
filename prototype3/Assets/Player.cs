/*****************

Planet Spherical Gravity (Multiple Planets) - Part 1
by SawneyStudios on YouTube and modified by me

https://www.youtube.com/watch?v=UeqfHkfPNh4

******************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Room;
    public float speed = 7;
    public Vector3 jump;
    public float jumpForce = 2.0f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        // Local character movement
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            z = 2 * Time.deltaTime * speed;
        }

        // Make the player go backward
        // If the 'S' key or DownArrow is pressed
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            z = -1 * Time.deltaTime * speed;
        }

        transform.Translate(x, 0, z);

    }


    // Jump (modified so the player can't spam the jump button and go in space, thus broke the game)
    public void OnCollisionStay(Collision other)
    {
        if (other.gameObject == Room)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, -150 * Time.deltaTime, 0);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, 150 * Time.deltaTime, 0);
            }

            this.gameObject.transform.Rotate(Input.mousePosition);
        }
    }
}
