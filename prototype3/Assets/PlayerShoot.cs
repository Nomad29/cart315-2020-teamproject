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
                // If there's a player bullet in the player bullet holder, shoot it
                GameObject Temporary_Ball_Handler = GameObject.FindGameObjectWithTag("PlayerBall");
                if (Temporary_Ball_Handler != null)
                {
                    Temporary_Ball_Handler.transform.Rotate(Vector3.left * 90);

                    //add a rigidbody component to the object
                    Rigidbody Temporary_RigidBody;
                    Temporary_RigidBody = Temporary_Ball_Handler.AddComponent<Rigidbody>();

                    // Tell the Ball to be "pushed" forward by an amount set by Ball_Forward_Force.
                    Temporary_RigidBody.AddForce(transform.forward * Ball_Forward_Force);

                    // Basic Clean Up, set the Balls to self destruct after 7 Seconds. Can be bigger number if used as a projectile and not a boost.
                    Destroy(Temporary_Ball_Handler, 7f);
                }
            }
        }

    }
}