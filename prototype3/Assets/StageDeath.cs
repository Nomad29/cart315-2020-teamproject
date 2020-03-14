using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Unity SceneManagement is important to include if there is a function that called a change in scenes.
using UnityEngine.SceneManagement;

public class StageDeath : MonoBehaviour
{
    // Gets the player
    public GameObject Player;

    // Sets the enemy life count of 5
    public int EnemyLifeCount = 5;

    void Start()
    {
        // Reset EnemyLife at each new game
        EnemyLife.EnemyLifeCount = 5;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            // Game Over screen after falling from the stage
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
}
