using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Unity SceneManagement is important to include if there is a function that called a change in scenes.
using UnityEngine.SceneManagement;


// *** This is used in the Game over scene for the button 'Retry' to function an let the player go back to the 'Game' scene.


public class GameOver : MonoBehaviour
{
    public void StartAgain()
    {
        // Goes to the 'Game' scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

}
