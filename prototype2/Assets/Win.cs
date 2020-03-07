using System.Collections;
// Unity UI is important to include if there is a variable that relates to a TextMesh Pro text.
using UnityEngine.UI;
using UnityEngine;
// Unity SceneManagement is important to include if there is a function that called a change in scenes.
using UnityEngine.SceneManagement;


public class Win : MonoBehaviour
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

    public void PlayAgain()
    {
        // Goes to the 'Game' scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        // Reset the score
        Checkpoint.Score = 0;
        AiCheckpoint.AiScore = 0;
    }

    public void Update()
    {
        //Starts the game again by pressing R (for Reset). Useful for playtesting class
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Goes to the 'Menu' scene at the beginning
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
            // Reset the score
            Checkpoint.Score = 0;
            AiCheckpoint.AiScore = 0;
        }

        //Starts the game again by pressing Space if people do not want to use the mouse
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Goes to the 'Game' scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            // Reset the score
            Checkpoint.Score = 0;
            AiCheckpoint.AiScore = 0;
        }
    }

}
