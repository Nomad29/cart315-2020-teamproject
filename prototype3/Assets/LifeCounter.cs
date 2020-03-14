using System.Collections;
// Unity UI is important to include if there is a variable that relates to a TextMesh Pro text.
using UnityEngine.UI;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{
    // Score from the EnemyLife
    public int EnemyLifeCount
    {
        get { return EnemyLifeCount; }
        set { EnemyLifeCount = value; }
    }

    // Text that will hold the Score
    public Text EnemyLifeCountText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Get the Enemy life counter number and insert it into a text
        EnemyLifeCountText.text = EnemyLife.EnemyLifeCount.ToString();
    }
}
