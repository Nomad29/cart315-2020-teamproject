using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Unity SceneManagement is important to include if there is a function that called a change in scenes.
using UnityEngine.SceneManagement;


// *** This is used in the 'Menu' scene at the beginning to let the player click on the 'Play' button to then go on the 'Game' scene.


public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        // Goes to the 'Game' scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
