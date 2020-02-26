/*****************

Planet Spherical Gravity (Multiple Planets)
by SawneyStudios on YouTube and modified by me for the spaceships items

https://www.youtube.com/watch?v=UeqfHkfPNh4

******************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemGravity : MonoBehaviour
{
    public GameObject Planet;
    public static int Score;

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
        Score = 0;
    }

    // Update is called once per frame
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

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Planet)
        {
            // Counter for the ships when they exit the planet after being pushed
            Score++;
            print("Score= " + Score);
        }

        // If all enemies are repelled, call the Win screen
        if (Score == 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

    }
}
