/*****************

Planet Spherical Gravity (Multiple Planets)
by SawneyStudios on YouTube and modified by me for the spaceships items

https://www.youtube.com/watch?v=UeqfHkfPNh4

******************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Unity SceneManagement is important to include if there is a function that called a change in scenes.
using UnityEngine.SceneManagement;

public class EnemyGravity : MonoBehaviour
{
    public GameObject Planet;
    // Variable made available for all scripts to use
    public static int Score;

    // Related to the base gravity script that we do not need to modify.
    float gravity = 100;
    bool OnGround = false;
    float distanceToGround;
    Vector3 Groundnormal;

    // Gets the item RigidBody. They all need a RigidBody installed on them in order to work.
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Precaution to take for bugs by constraining the player's Rigidbody rotation
        rb.freezeRotation = true;
        // Starting score of zero
        Score = 0;
    }

    // The Update() function does not have to be modified, its the base of the gravity for the items that hold this script
    void Update()
    {

        // Ground control
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
        {
            distanceToGround = hit.distance;
            Groundnormal = hit.normal;

            // Makes the throwed object float in space instead if propelled enough
            if (distanceToGround >= 0.1f)
            {
                OnGround = false;
            }
            else
            {
                OnGround = true;
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

}
