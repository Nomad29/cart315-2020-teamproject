using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Unity SceneManagement is important to include if there is a function that called a change in scenes.
using UnityEngine.SceneManagement;


// *** This is used in the Game over scene for the button 'Retry' to function an let the player go back to the 'Game' scene.


public class GameOver : MonoBehaviour
{
    // Score from the Checkpoint script
    public int Score
    {
        get { return Score; }
        set { Score = value; }
    }
    // AiScore from the AiCheckpoint script
    public int AiScore
    {
        get { return AiScore; }
        set { AiScore = value; }
    }

    public void StartAgain()
    {
        // Goes to the 'Game' scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        // Reset the score
        Checkpoint.Score = 0;
        AiCheckpoint.AiScore = 0;
    }

    public void Update()
    {
        //Starts the game again by pressing Space if people do not want to use the mouse
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Goes to the 'Game' scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
            // Reset the score
            Checkpoint.Score = 0;
            AiCheckpoint.AiScore = 0;
        }
    }

}
