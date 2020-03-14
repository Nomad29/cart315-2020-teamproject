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
        if (other.gameObject == Enemy)
        {
            // Apply new red material to the two parts of the turret enemy
            TurretTop.gameObject.GetComponent<Renderer>().material = newMaterial;
            TurretBottom.gameObject.GetComponent<Renderer>().material = newMaterial;

            Debug.Log("EnemyLife -1");

            // Start a delay function of 0.2 second
            StartCoroutine(Reuse());

            // Enemy -1 life if touched by one player's ball
            EnemyLifeCount--;
        }
    }

    public IEnumerator Reuse()
    {
        // Start a delay of 0.2 second
        yield return new WaitForSeconds(0.2f);

        // After delay, gives the enemy its normal material
        TurretTop.gameObject.GetComponent<Renderer>().material = oldMaterial;
        TurretBottom.gameObject.GetComponent<Renderer>().material = oldMaterial;
    }

    public IEnumerator Wait()
    {
        // Start a delay of 0.5 second
        yield return new WaitForSeconds(0.5f);

        // Win screen after 5 hits by the player
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
