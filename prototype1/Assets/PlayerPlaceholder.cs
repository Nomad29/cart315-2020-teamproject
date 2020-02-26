/*****************

Planet Spherical Gravity (Multiple Planets) - Part 2
by SawneyStudios on YouTube

https://www.youtube.com/watch?v=UeqfHkfPNh4

******************/


// *** The PlaceHolder is important if you want to keep the smooth view angle from afar as it is in my third prototype.


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
        // Smooth positioning of the camera inside the planet
        transform.position = Vector3.Lerp(transform.position, Player.transform.position, 0.1f);
        Vector3 gravDirection = (transform.position - Planet.transform.position).normalized;

        // Smooth rotation
        Quaternion toRotation = Quaternion.FromToRotation(transform.up, gravDirection) * transform.rotation;
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 0.1f);
    }

}
