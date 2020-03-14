using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Unity SceneManagement is important to include if there is a function that called a change in scenes.
using UnityEngine.SceneManagement;

public class EnemyLife : MonoBehaviour
{
    public static int EnemyLifeCount;
    public GameObject Enemy;
    public GameObject TurretTop;
    public GameObject TurretBottom;
    public Material newMaterial;
    public Material oldMaterial;

    // Start is called before the first frame update
    void Start()
    {
        // Reset EnemyLife at each new game
        EnemyLifeCount = 0;

        Enemy = GameObject.Find("Enemy");
        TurretTop = GameObject.Find("Top");
        TurretBottom = GameObject.Find("Base");
    }
    
    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Enemy)
        {
            TurretTop.gameObject.GetComponent<Renderer>().material = newMaterial;
            TurretBottom.gameObject.GetComponent<Renderer>().material = newMaterial;
            Debug.Log("EnemyLife -1");

            // Start a delay function of 0.2 second
            StartCoroutine(Reuse());
        }
    }

    public IEnumerator Reuse()
    {
        // Start a delay of 0.2 second
        yield return new WaitForSeconds(0.2f);
        TurretTop.gameObject.GetComponent<Renderer>().material = oldMaterial;
        TurretBottom.gameObject.GetComponent<Renderer>().material = oldMaterial;
    }
}
