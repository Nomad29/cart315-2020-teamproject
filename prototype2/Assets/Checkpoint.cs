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

    public Player playerScript;

    public Color whitee;

    string checkPointColor;
    string[] colorList = new string[]{"red","green","blue"}; 

    // Start is called before the first frame update
    void Start()
    {
        setFlagColor();
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

            //Turn the player's flag and bike into the corresponding color
            if (checkPointColor == "blue")
            {
                Player.tag = "PlayerBlue";
                GameObject.Find("playerFLAG").GetComponent<MeshRenderer>().material = playerScript.playerFlagB;
                GameObject.Find("pasted__pCube2").GetComponent<MeshRenderer>().material = playerScript.playerFlagB;


            }
            else if (checkPointColor == "red")
            {
                Player.tag = "PlayerRed";
                GameObject.Find("playerFLAG").GetComponent<MeshRenderer>().material = playerScript.playerFlagR;
                GameObject.Find("pasted__pCube2").GetComponent<MeshRenderer>().material = playerScript.playerFlagR;

            }
            else if (checkPointColor == "green")
            {
                Player.tag = "PlayerGreen";
                GameObject.Find("playerFLAG").GetComponent<MeshRenderer>().material = playerScript.playerFlagG;
                GameObject.Find("pasted__pCube2").GetComponent<MeshRenderer>().material = playerScript.playerFlagG;

            }

            Debug.Log("Score +1");
        }
    }

    void setFlagColor()
    {
        //randomize the checkpoint's color
        checkPointColor = colorList[Random.Range(0, colorList.Length)];
        Debug.Log("checkcolor " + checkPointColor);

        if (checkPointColor == "blue")
        {
            Flag.transform.GetComponent<Renderer>().material.color = new Color32(68, 117, 240, 255);
        }
        else if (checkPointColor == "red")
        {
            Flag.transform.GetComponent<Renderer>().material.color = new Color32(240, 72, 68, 255);
        }
        else if (checkPointColor == "green")
        {
            Flag.transform.GetComponent<Renderer>().material.color = new Color32(9, 163, 113, 255);
        }
    }
    
    public IEnumerator Reuse()
    {
        // Start a delay of 7 seconds
        yield return new WaitForSeconds(7.0f);
        // Enable back the checkpoint's collider
        this.gameObject.GetComponent<Collider>().enabled = true;
        // Make the flag change color back to normal
        setFlagColor();
    }

}