/*****************

How to shoot Balls
by Bracer Jack on YouTube

https://www.youtube.com/watch?v=FD9HZB0Jn1w

******************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Drag in the Ball Emitter from the Component Inspector.
    public GameObject Ball_Emitter;

    // Drag in the Ball Prefab from the Component Inspector.
    public GameObject Ball;

    // Enter the Speed of the Ball from the Component Inspector.
    public float Ball_Forward_Force;

    // Number of Balls to shoot
    public int numberOfObjects = 1;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        // Keeps the users from shooting more than one Ball at a time
        for (int i = 0; i < numberOfObjects; i++)
        {

            // If left mouse click is pushed.
            // The Down does not let the player using continuously the shoot mouse click
            if (Input.GetMouseButtonDown(0))
            {
                // The Ball instantiation happens here.
                GameObject Temporary_Ball_Handler;
                Temporary_Ball_Handler = Instantiate(Ball, Ball_Emitter.transform.position, Ball_Emitter.transform.rotation) as GameObject;
                Debug.Log("Ball shooted");

                // Sometimes Balls may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
                Temporary_Ball_Handler.transform.Rotate(Vector3.left * 90);

                // Retrieve the Rigidbody component from the instantiated Ball and control it. 
                // Important that the things you want to fire upon with the Balls to possess a RigidBody also.
                Rigidbody Temporary_RigidBody;
                Temporary_RigidBody = Temporary_Ball_Handler.GetComponent<Rigidbody>();

                // Tell the Ball to be "pushed" forward by an amount set by Ball_Forward_Force.
                Temporary_RigidBody.AddForce(transform.forward * Ball_Forward_Force);

                // Basic Clean Up, set the Balls to self destruct after 30 Seconds. Can be bigger number if used as a projectile and not a boost.
                Destroy(Temporary_Ball_Handler, 30f);
            }
        }

    }
}