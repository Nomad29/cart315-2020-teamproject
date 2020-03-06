using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aianim : MonoBehaviour
{
    // Variables for triggered animations for going left and right
    public Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        // Initialization for animations left and right
        myAnim = GetComponent<Animator>();
    }

    void Update()
    {
        // If the 'W' key or UpArrow is pressed
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // Get the animation when turning right
            myAnim.SetTrigger("Walk");
        }

        // If the 'S' key or DownArrow is pressed
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // Get the animation when turning right
            myAnim.SetTrigger("Walk");
        }

        // If the 'A' key or LeftArrow is pressed
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // Get the animation when turning left
            myAnim.SetTrigger("Walk");
        }

        // If the 'D' key or RightArrow is pressed
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // Get the animation when turning right
            myAnim.SetTrigger("Walk");
        }

    }

}
