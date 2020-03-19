using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Unity SceneManagement is important to include if there is a function that called a change in scenes.
using UnityEngine.SceneManagement;

public class EnemyLife : MonoBehaviour
{
    // Sets the enemy life count of 5
    public static int EnemyLifeCount = 5;

    // Sets variables for different gameobject from the scene
    public GameObject Enemy;
    public GameObject TurretTop;
    public GameObject TurretBottom;
    public Material newMaterial;
    public Material oldMaterial;

    // Start is called before the first frame update
    void Start()
    {
        // Gets gameobjects from scene
        Enemy = GameObject.Find("Enemy");
        TurretTop = GameObject.Find("Top");
        TurretBottom = GameObject.Find("Base");
    }
    
    // Update is called once per frame
    void Update()
    {
        // If the enemy is touched five times
        if (EnemyLifeCount == 0)
        {
            // Start a delay function of 0.5 second
            
            StartCoroutine(Wait());
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBall"))
        {
           
            //First, retrieve this playerball's color
            Color PlayerColor = other.gameObject.GetComponent<Renderer>().material.color;

            //Then retrieve the turret's vulnerable color according to the UI indicator
            GameObject EnemyVulnerabilityIndicator = GameObject.Find("Color");
            Color EnemyVulnerability = EnemyVulnerabilityIndicator.GetComponent<UnityEngine.UI.Text>().color;

            //if the colors match, -1 life
            if (PlayerColor == EnemyVulnerability)
            {
                EnemyLifeCount--;

                // Apply new red material to the two parts of the turret enemy
                TurretTop.gameObject.GetComponent<Renderer>().material = newMaterial;
                TurretBottom.gameObject.GetComponent<Renderer>().material = newMaterial;

                Debug.Log("EnemyLife -1");

                // Start a delay function of 0.2 second
                StartCoroutine(Reuse());
            }

            //Destroy the playerball
            Destroy(other.gameObject);

        }
    }

    public IEnumerator Reuse()
    {
        print("turret return");
        // Start a delay of 0.2 second
        yield return new WaitForSeconds(0.2f);


        print("turret return 2s");

        // After delay, gives the enemy its normal material
        TurretTop.gameObject.GetComponent<Renderer>().material = oldMaterial;
        TurretBottom.gameObject.GetComponent<Renderer>().material = oldMaterial;
    }

    public IEnumerator Wait()
    {
        print("gamewon");
        // Start a delay of 0.5 second
        yield return new WaitForSeconds(0.5f);
        EnemyLifeCount = 5;
        print("gamewon2");
        // Win screen after 5 hits by the player
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
