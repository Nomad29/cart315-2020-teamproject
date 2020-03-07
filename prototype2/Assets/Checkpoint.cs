using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Unity SceneManagement is important to include if there is a function that called a change in scenes.
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    // Checkpoint score of the player.
    public static int Score;
    public GameObject Player;
    public GameObject Flag;

    public Color whitee;
    public Color normalee;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Score of 15 checkpoints passed to win
        if (Score == 15)
        {
            // To delay a bit the delay before showing up the next screen since its pretty fast by default
            Invoke("DelayedAction", 0.5f);
        }
    }

    void DelayedAction()
    {
        // Goes to 'Win' scene because win win
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            // Add +1 to the score
            Score++;
            // Disable collider of checkpoint for keeping player from spaming one
            this.gameObject.GetComponent<Collider>().enabled = false;
            // Start a delay function of 7 seconds
            StartCoroutine(Reuse());
            // Make the flag change color when used
            Flag.transform.GetComponent<Renderer>().material.color = whitee;
            Debug.Log("Score +1");
        }
    }

    public IEnumerator Reuse()
    {
        // Start a delay of 7 seconds
        yield return new WaitForSeconds(7.0f);
        // Enable back the checkpoint's collider
        this.gameObject.GetComponent<Collider>().enabled = true;
        // Make the flag change color back to normal
        Flag.transform.GetComponent<Renderer>().material.color = normalee;
    }

}