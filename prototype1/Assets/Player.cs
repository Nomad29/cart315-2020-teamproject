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
    public float speed = 7;
    public float JumpHeight = 7f;

    float gravity = 100;
    bool OnGround = false;

    float distanceToGround;
    Vector3 Groundnormal;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(x, 0, z);

        // Local rotation
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 150 * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -150 * Time.deltaTime, 0);
        }

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

    // Jump (modified by me, so the player can't spam the jump button and go in space, thus broke the game)
    public void OnCollisionStay(Collision other)
    {
        if (other.gameObject == Planet)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(transform.up * 5000 * JumpHeight * Time.deltaTime);
            }
        }
    }
}
