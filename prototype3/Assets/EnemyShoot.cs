/*****************

How to shoot Balls
by Bracer Jack on YouTube

https://www.youtube.com/watch?v=FD9HZB0Jn1w

******************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    // Drag in the Ball Emitter from the Component Inspector.
    public GameObject Ball_Emitter;

    // Drag in the Ball Prefab from the Component Inspector.
    public GameObject Ball;

    // Enter the Speed of the Ball from the Component Inspector.
    public float Ball_Forward_Force;

    // Number of Balls to shoot
    public int numberOfObjects = 1;

    // Array of colors for the balls
    public Color[] colors = new Color[3];

    // Enemy ball prefab for color change
    public GameObject EnemyBall;

    // Turret's eye for color change
    public GameObject EnemyEye;
    // Turret's eye colors
    public Color cyan;
    public Color red;
    public Color green;

    // Use this for initialization
    void Start()
    {
        // Enemy ball colors defined here
        colors[0] = Color.cyan;
        colors[1] = Color.red;
        colors[2] = Color.green;

        // Invokes the shoot function at interval of 7-10 seconds and repeated afterward
        InvokeRepeating("Shoot", Random.Range(7.0f, 10.0f), Random.Range(7.0f, 10.0f));
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeColor()
    {
        // Gets the enemy ball material and sets it to a random choice of colors among the color defined above in void Start()
        EnemyBall.gameObject.GetComponent<Renderer>().sharedMaterial.color = colors[Random.Range(0, colors.Length)];

        Debug.Log("Ball color changed");

        // Sets here what happens when the enemy ball is cyan
        if (EnemyBall.gameObject.GetComponent<Renderer>().sharedMaterial.color == Color.cyan)
        {
            // Changes the enemy's eye to cyan
            EnemyEye.gameObject.GetComponent<Renderer>().material.color = cyan;

            Debug.Log("Turret eye changed cyan");
        }

        // Sets here what happens when the enemy ball is red
        else if (EnemyBall.gameObject.GetComponent<Renderer>().sharedMaterial.color == Color.red)
        {
            // Changes the enemy's eye to red
            EnemyEye.gameObject.GetComponent<Renderer>().material.color = red;

            Debug.Log("Turret eye changed red");
        }

        // Sets here what happens when the enemy ball is green
        else if (EnemyBall.gameObject.GetComponent<Renderer>().sharedMaterial.color == Color.green)
        {
            // Changes the enemy's eye to green
            EnemyEye.gameObject.GetComponent<Renderer>().material.color = green;

            Debug.Log("Turret eye changed green");
        }
    }

    public void Shoot()
    {
        // Keeps the users from shooting more than one Ball at a time
        for (int i = 0; i<numberOfObjects; i++)
        {
            // The Ball instantiation happens here.
            GameObject Temporary_Ball_Handler;

            Temporary_Ball_Handler = Instantiate(Ball, Ball_Emitter.transform.position, Ball_Emitter.transform.rotation) as GameObject;
            Debug.Log("Enemy Ball shooted");

            // Sometimes Balls may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            Temporary_Ball_Handler.transform.Rotate(Vector3.left* 90);

            // Retrieve the Rigidbody component from the instantiated Ball and control it. 
            // Important that the things you want to fire upon with the Balls to possess a RigidBody also.
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Ball_Handler.GetComponent<Rigidbody>();

            // Tell the Ball to be "pushed" forward by an amount set by Ball_Forward_Force.
            Temporary_RigidBody.AddForce(transform.forward* Ball_Forward_Force);

            // Basic Clean Up, set the Balls to self destruct after 7 Seconds. Can be bigger number if used as a projectile and not a boost.
            Destroy(Temporary_Ball_Handler, 7f);

            // Calls the change color function above at each shooting
            ChangeColor();
        }
    }
}