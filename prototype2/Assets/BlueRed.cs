using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueRed : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            // Write here what happens when the player goes on the intersection between the blue and red roads
        }
    }
}
