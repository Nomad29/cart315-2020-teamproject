using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

        // If SPACE is pressed, starts the whole thing again
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -3);
        }
    }
}
