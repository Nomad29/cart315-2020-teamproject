/*****************

Planet Spherical Gravity (Multiple Planets) - Part 2
by SawneyStudios on YouTube

https://www.youtube.com/watch?v=UeqfHkfPNh4

******************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaceholder : MonoBehaviour
{
    public GameObject Player;
    public GameObject Planet;

    // Update is called once per frame
    void Update()
    {
        // Smooth positioning
        transform.position = Vector3.Lerp(transform.position, Player.transform.position, 0.1f);
        Vector3 gravDirection = (transform.position - Planet.transform.position).normalized;

        // Smooth rotation
        Quaternion toRotation = Quaternion.FromToRotation(transform.up, gravDirection) * transform.rotation;
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 0.1f);
    }

}
