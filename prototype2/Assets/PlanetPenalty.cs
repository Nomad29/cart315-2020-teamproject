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
        else if (OnBlue == true && OnRed == true)
        {
            //if player has blue or red tag --> player is fine
            if (Player.tag == "PlayerBlue" || Player.tag == "PlayerRed")
            {
                playerScript.speed = 7;
            }
            else
            {
                playerScript.speed = 3;//else the speed is slightly lower
            }
        }
        else if (OnBlue == true && OnGreen == true)
        {
            //if player has blue or green tag --> player is fine
            if (Player.tag == "PlayerBlue" || Player.tag == "PlayerGreen")
            {
                playerScript.speed = 7;
            }
            else
            {
                playerScript.speed = 3;//else the speed is slightly lower
            }
        }
        else if (OnGreen == true && OnRed == true)
        {
            //if player has green or red tag --> player is fine
            if (Player.tag == "PlayerRed" || Player.tag == "PlayerGreen")
            {
                playerScript.speed = 7;
            }
            else
            {
                playerScript.speed = 3;//else the speed is slightly lower
            }
        }
        else if (OnBlue == true)
        {
            if (Player.tag == "PlayerBlue")
            {
                playerScript.speed = 7;
            }
            else
            {
                playerScript.speed = 3;
            }
        }
        else if (OnRed == true)
        {
            if (Player.tag == "PlayerRed")
            {
                playerScript.speed = 7;
            }
            else
            {
                playerScript.speed = 3;
            }
        }
        else if (OnGreen == true)
        {
            if (Player.tag == "PlayerGreen")
            {
                playerScript.speed = 7;
            }
            else
            {
                playerScript.speed = 3;
            }
        }
    }

}
