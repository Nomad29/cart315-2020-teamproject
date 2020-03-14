using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Unity SceneManagement is important to include if there is a function that called a change in scenes.
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public static int PlayerLifeCount;
    public GameObject PlayerAvatar;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerAvatar = GameObject.Find("Player");
        // Reset PlayerLife at each new game
        PlayerLifeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerLifeCount == 1)
        {
            // Start a delay function of 0.5 second
            StartCoroutine(Reuse());
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PlayerAvatar)
        {
            Debug.Log("Player dead");
            PlayerLifeCount++;
        }
    }

    public IEnumerator Reuse()
    {
        // Start a delay of 0.5 second
        yield return new WaitForSeconds(0.5f);

        // Game Over screen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
