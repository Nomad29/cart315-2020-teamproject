using System.Collections;
// Unity UI is important to include if there is a variable that relates to a TextMesh Pro text.
using UnityEngine.UI;
using UnityEngine;
// Unity SceneManagement is important to include if there is a function that called a change in scenes.
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public float timeLeft = 60.0f; // 60 seconds is the Timer, could be more
    public Text startText; // used for showing the words 'Time left'


    void Update()
    {
        timeLeft -= Time.deltaTime;
        startText.text = (timeLeft).ToString("0");
        // If the timer goes to zero, the scene manager goes to +2 (= the game over scene)
        // To see the scenes order and calculate the outcome, you just need to go in the Unity menu File -> Build Settings. 
        if (timeLeft < 0)
        {
            // Goes to 'Win' scene that will show to player its score
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}