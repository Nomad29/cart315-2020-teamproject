using System.Collections;
// Unity UI is important to include if there is a variable that relates to a TextMesh Pro text.
using UnityEngine.UI;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    // Score from the Food script
    public int Score
    {
        get { return Score; }
        set { Score = value; }
    }

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = Food.Score.ToString();
    }
}
