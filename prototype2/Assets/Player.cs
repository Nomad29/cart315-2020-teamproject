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
    public GameObject Planet;
    // These two floats can be changed in Unity also
    public float speed = 5;

    // Related to the base gravity script that we do not need to modify.
    float gravity = 100;
    bool OnGround = false;
    float distanceToGround;
    Vector3 Groundnormal;

    // Gets the player's RigidBody. It needs a RigidBody installed on it in order to work.
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Precaution to take for bugs by constraining the player's Rigidbody rotation
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

        // These next parts of the Update() function does not have to be modified, its the base of the gravity for the items that hold this script
        GroundControl();
        GravityAndRotation();


    }

    void Move()
    {
        MovementsInput();
    }


    public void MovementsInput()
    {
        // Gets the basis of the player's movements
        float z = 0f;//vertical placement
        float x = 0f;

        //old x and z:         
        //float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed; // if there is no horizontal input, x = 0
        //float z = Input.GetAxis("Vertical") * Time.deltaTime * speed; // if there is no vertical input, z = 0

        // Make the player go foward
        // If the 'W' key or UpArrow is pressed
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
           // The only thing modifiable in this string is the number '150'. Going higher will make the player's avatar will do a bigger rotation while smaller will to the opposite.
           z = 2 * Time.deltaTime * speed;
        }

        // Make the player go backward
        // If the 'S' key or DownArrow is pressed
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // The only thing modifiable in this string is the number '150'. Going higher will make the player's avatar will do a bigger rotation while smaller will to the opposite.
            z = -1 * Time.deltaTime * speed;
        }

        // If the 'A' key or LeftArrow is pressed
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // Make the player go foward a bit also
            z = 1 * Time.deltaTime * speed;
            // The only thing modifiable in this string is the number '-150'. Going higher will make the player's avatar will do a bigger rotation while smaller will to the opposite.
            // Makes sures the inputs gets the same number or the movements will be unbalanced.
            transform.Rotate(0, -150 * Time.deltaTime, 0);
        }

        // Change character direction by rotation: doesn't actually move the character around (as it affects the y axis) but rather the rotation range
        // If the 'D' key or RightArrow is pressed
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // Make the player go foward a bit also
            z = 1 * Time.deltaTime * speed;
            // The only thing modifiable in this string is the number '150'. Going higher will make the player's avatar will do a bigger rotation while smaller will to the opposite.
            transform.Rotate(0, 150 * Time.deltaTime, 0);
        }

        // Lets the player move on the planet perfectly in 3D. Without it, the planet would walk on the sphere like its planar.
        transform.Translate(x, 0, z);
        // update the snake's global position
        //rb.transform.position = head_Body.transform.position;

    }

    void GroundControl()
    {
        // Ground control
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
        {
            distanceToGround = hit.distance;
            Groundnormal = hit.normal;

            if (distanceToGround <= 0.1f)
            {
                OnGround = true;
            }
            else
            {
                OnGround = false;
            }
        }
    }

    void GravityAndRotation()
    {
        // Gravity and rotation
        Vector3 gravDirection = (transform.position - Planet.transform.position).normalized;

        if (OnGround == false)
        {
            rb.AddForce(gravDirection * -gravity);
        }

        //

        Quaternion toRotation = Quaternion.FromToRotation(transform.up, Groundnormal) * transform.rotation;
        transform.rotation = toRotation;
    }

}
