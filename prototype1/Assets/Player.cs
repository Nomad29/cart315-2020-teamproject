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
    public float speed = 7;
    public float JumpHeight = 7f;

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
    void Update()
    {
        // Gets the basis of the player's movements
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        // Lets the player move on the planet perfectly in 3D. Without it, the planet would walk on the sphere like its planar.
        transform.Translate(x, 0, z);

        // Player inputs by rotation. Can be changed to translation I think because as the prototype is now, the player cannot move left or right without moving foward or backyard also.
        // If the 'D' key is pressed
        if (Input.GetKey(KeyCode.D))
        {
            // The only thing modifiable in this string is the number '150'. Going higher will make the player's avatar will do a bigger rotation while smaller will to the opposite.
            transform.Rotate(0, 150 * Time.deltaTime, 0);
        }
        // If the 'A' key is pressed
        if (Input.GetKey(KeyCode.A))
        {
            // The only thing modifiable in this string is the number '-150'. Going higher will make the player's avatar will do a bigger rotation while smaller will to the opposite.
            // Makes sures the inputs gets the same number or the movements will be unbalanced.
            transform.Rotate(0, -150 * Time.deltaTime, 0);
        }

        // These next parts of the Update() function does not have to be modified, its the base of the gravity for the items that hold this script
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

    // Jump (modified by me, so the player can't spam the jump button and go in space, thus broken the game)
    public void OnCollisionStay(Collision other)
    {
        // The player can only jump again if he touches the planet
        if (other.gameObject == Planet)
        {
            // If the 'Space' key is pressed
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(transform.up * 5000 * JumpHeight * Time.deltaTime);
            }
        }
    }
}
