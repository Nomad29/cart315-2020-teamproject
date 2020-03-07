using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Unity SceneManagement is important to include if there is a function that called a change in scenes.
using UnityEngine.SceneManagement;

public class AiCheckpoint : MonoBehaviour
{
    // Checkpoint score of the player.
    public static int AiScore;
    public GameObject Turtle;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Score of 15 checkpoints passed to win
        if (AiScore == 15)
        {
            // To delay a bit the delay before showing up the next screen since its pretty fast by default
            Invoke("DelayedAction", 0.5f);
        }
    }

    void DelayedAction()
    {
        // Goes to 'Game over' scene since AI won
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Turtle)
        {
            // Add +1 to the score
            AiScore++;
            Debug.Log("AiScore +1");
        }
    }

}