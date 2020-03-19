using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInteraction : MonoBehaviour
{
    private GameObject SelectedObj;

    public GameObject PlayerBullet;

    public GameObject BulletHolder;

    public GameObject PlayerBulletIndicator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //If player click left button when an object is in range, then the selected object gets destroyed, and a new identical "bullet" object is instantiated as a child of PlayerShootingHolder
        if (Input.GetMouseButtonDown(1))
        {
            if (SelectedObj != null)
            {
                //Set the new bullet color 
                Color newBulletCol = Color.black;
                //Debug.Log(SelectedObj.tag);
                newBulletCol = SelectedObj.GetComponent<Renderer>().material.color;

                //destroy the selected object
                Destroy(SelectedObj);

                //destroy the previous bullet if there's any
                GameObject prevBullet = GameObject.FindGameObjectWithTag("PlayerBall");
                if (prevBullet != null)
                {
                    Destroy(prevBullet);
                }

                //remove the UI pickup text if it's still there
                GameObject pickupNoti = GameObject.Find("PickUp");
                pickupNoti.GetComponent<UnityEngine.UI.Text>().text = null;


                //Create a new obj called playerbullet on the same position as PlayerShootingHolder
                GameObject newBullet;
                newBullet = Instantiate(PlayerBullet, BulletHolder.transform.position, BulletHolder.transform.rotation) as GameObject;
                //assign the new bullet color to the game object
                newBullet.GetComponent<Renderer>().material.color = newBulletCol;
                //make it a child of PlayerShooting Holder
                newBullet.transform.parent = BulletHolder.transform;
                //add tag to the bullet
                newBullet.tag = "PlayerBall";

            }
        }

    }

    void BallInRange(GameObject selectedBall)
    {
        string ballColor = null;
        if (selectedBall.GetComponent<Renderer>().material.color == Color.red)
        {
            ballColor = "Red";
        }
        if (selectedBall.GetComponent<Renderer>().material.color == Color.cyan)
        {
            ballColor = "Blue";
        }
        if (selectedBall.GetComponent<Renderer>().material.color == Color.green)
        {
            ballColor = "Green";
        }

        //make the pickup notification visible
        GameObject pickupNoti = GameObject.Find("PickUp");
        pickupNoti.GetComponent<UnityEngine.UI.Text>().text = ballColor + " ball! Right mouse to pick up";
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("PickableRed") || col.gameObject.CompareTag("PickableGreen") || col.gameObject.CompareTag("PickableCyan") || col.gameObject.CompareTag("EnemyBall"))
        {
            //Debug.Log(col.gameObject.tag);
            SelectedObj = col.gameObject;
            BallInRange(col.gameObject);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("PickableRed") || col.gameObject.CompareTag("PickableGreen") || col.gameObject.CompareTag("PickableCyan") || col.gameObject.CompareTag("EnemyBall"))
        {
            SelectedObj = null;
            GameObject pickupNoti = GameObject.Find("PickUp");
            pickupNoti.GetComponent<UnityEngine.UI.Text>().text = null;
        }
    }
}
