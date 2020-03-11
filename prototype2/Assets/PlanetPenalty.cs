using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPenalty : MonoBehaviour
{
    public GameObject Player;

    public Player playerScript;

    public bool OnBlue = false;
    public bool OnRed = false;
    public bool OnGreen = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (OnBlue == false && OnRed == false && OnGreen == false)
        {

            // Player moves very slowly
            playerScript.speed = 1;
        }
        else
        {
            playerScript.speed = 5;
        }
    }

}
