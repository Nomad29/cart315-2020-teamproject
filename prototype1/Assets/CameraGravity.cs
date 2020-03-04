/*****************

Planet Spherical Gravity (Multiple Planets) - Part 3
by SawneyStudios on YouTube

https://www.youtube.com/watch?v=UeqfHkfPNh4

******************/


// *** This code is for moving the camera around the player when clicking on the left mouse button.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGravity : MonoBehaviour
{
    public GameObject target;
    public float xSpeed = 3f;
    float sensitivity = 17f;

    float minFov = 35;
    float maxFov = 100;

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //transform.RotateAround(target.transform.position, transform.up, Input.GetAxis("Mouse X") * xSpeed);
        //transform.RotateAround(target.transform.position, transform.right, Input.GetAxis("Mouse Y") * xSpeed);
        //}
    }
}
