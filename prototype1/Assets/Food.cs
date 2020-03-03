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

    // Start is called before the first frame update
    void Start()
    {
       this.gameObject.SetActive(true);

        // Reset the score at each new game
        Score = 0;

        // Gets the Player script
        myPlayerScript = GameObject.Find("Player").GetComponent<Player>();

        PlayerPrefs.SetInt("Score", Score);
        PlayerPrefs.Save();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Snake)
        {
            Score++;
            this.gameObject.SetActive(false);
            // Execute the AddBodyPart function from the Player script
            myPlayerScript.AddBodyPart();
            Debug.Log("Score++");
        }
    }
}
