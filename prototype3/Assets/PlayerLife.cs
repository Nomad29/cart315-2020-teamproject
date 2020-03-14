using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Unity SceneManagement is important to include if there is a function that called a change in scenes.
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    // Sets the playerlifecount public to all scripts of the scene
    public static int PlayerLifeCount;
    // Get the jammo avatar player
    public GameObject PlayerAvatar;
    
    // Start is called before the first frame update
    void Start()
    {
        // Gets the player gameobject
        PlayerAvatar = GameObject.Find("Player");
        // Reset PlayerLife at each new game
        PlayerLifeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // If the player is touched one time
        if (PlayerLifeCount == 1)
        {
            // Start a delay function of 0.5 second
            StartCoroutine(Wait());
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        // If the enemy ball touched the player
        if (other.gameObject == PlayerAvatar)
        {
            Debug.Log("Player dead");
            // Add the death counter of the player
            PlayerLifeCount++;
        }
    }

    public IEnumerator Wait()
    {
        // Start a delay of 0.5 second
        yield return new WaitForSeconds(0.5f);

        // Game Over screen after being touched one time by the enemy ball
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
