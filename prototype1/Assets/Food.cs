using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Drag in the Player from the Component Inspector.
    public GameObject Snake;
    Player myPlayerScript;
    // Score of the player.
    public static int Score;
    // Drag in the Food prefab from the Component Inspector.
    public GameObject foodPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Reset the score at each new game
        Score = 0;

        // Gets the Player script
        myPlayerScript = GameObject.Find("Player").GetComponent<Player>();
        // Snake is now refered as the Player gameObject
        Snake = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Snake)
        { 
            // Add +1 to the score
            Score++;
            // Start a delay function of 30 seconds
            StartCoroutine(Reapparition());
            // Make the food pelet disappear
            this.gameObject.GetComponent<Renderer>().enabled = false;
            this.gameObject.GetComponent<Collider>().enabled = false;
            // Execute the AddBodyPart function tree times from the Player script so the player gets more challenge (not touching the tail)
            myPlayerScript.AddBodyPart();
            myPlayerScript.AddBodyPart();
            myPlayerScript.AddBodyPart();
            Debug.Log("Score++");
        }
    }

    public IEnumerator Reapparition()
    {
        // Start a delay of 30 seconds
        yield return new WaitForSeconds(30.0f);
        // Make the food pelet reappear
        this.gameObject.GetComponent<Renderer>().enabled = true;
        this.gameObject.GetComponent<Collider>().enabled = true;
    }

}
