using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlue : MonoBehaviour
{
    public GameObject Player;

    public PlanetPenalty planetPenalty;

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
            planetPenalty.OnBlue = true;
            Debug.Log("onBlue");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            planetPenalty.OnBlue = false;
            Debug.Log("outBlue");
        }
    }
}
