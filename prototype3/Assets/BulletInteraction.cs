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
                if (SelectedObj.CompareTag("PickableRed"))
                {
                    newBulletCol = Color.red;
                }
                if (SelectedObj.CompareTag("PickableCyan"))
                {
                    newBulletCol = Color.cyan;
                }
                if (SelectedObj.CompareTag("PickableGreen"))
                {
                    newBulletCol = Color.green;
                }

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

        //DETECTION BY RAYCAST, USED WHEN ATTACH SCRIPT TO PLAYER CHILD OBJECT
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3f))
        //{
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        //if (hit.collider.gameObject.tag == "PickableRed" || hit.collider.gameObject.tag == "PickableCyan" || hit.collider.gameObject.tag == "PickableGreen")
        //{
        //SelectedObj = hit.collider.gameObject;
        //BallInRange(SelectedObj);

        //If player press F when an object is in range, then the selected object gets destroyed, and a new identical "bullet" object is instantiated as a child of PlayerShootingHolder
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        // Debug.Log("Fpressed");
        //}

        //}


        //} else //Let the ball resume their original color when not hit by raycast
        //{
        //    if (SelectedObj != null)
        //    {
        //        if (SelectedObj.tag == "PickableRed")
        //        {
        //            SelectedObj.GetComponent<Renderer>().material.color = Color.red;
        //       }
        //       if (SelectedObj.tag == "PickableCyan")
        //       {
        //           SelectedObj.GetComponent<Renderer>().material.color = Color.cyan;
        //      }
        //      if (SelectedObj.tag == "PickableGreen")
        //       {
        //            SelectedObj.GetComponent<Renderer>().material.color = Color.green;
        //        }

        //        //Make the pickup notification invisible again
        //        GameObject pickupNoti = GameObject.Find("PickUp");
        //        pickupNoti.GetComponent<UnityEngine.UI.Text>().text = null;
        //
        //       //set the selected object back to null
        //        SelectedObj = null;
        //   }
        //}
    }

    void BallInRange(GameObject selectedBall)
    {
        string ballColor = null;
        if (selectedBall.tag == "PickableRed")
        {
            ballColor = "Red";
        }
        if (selectedBall.tag == "PickableCyan")
        {
            ballColor = "Blue";
        }
        if (selectedBall.tag == "PickableGreen")
        {
            ballColor = "Green";
        }

        //make the pickup notification visible
        GameObject pickupNoti = GameObject.Find("PickUp");
        pickupNoti.GetComponent<UnityEngine.UI.Text>().text = ballColor + " ball! Right mouse to pick up";
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("PickableRed") || col.gameObject.CompareTag("PickableGreen") || col.gameObject.CompareTag("PickableCyan"))
        {
            //Debug.Log(col.gameObject.tag);
            SelectedObj = col.gameObject;
            BallInRange(col.gameObject);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("PickableRed") || col.gameObject.CompareTag("PickableGreen") || col.gameObject.CompareTag("PickableCyan"))
        {
            SelectedObj = null;
            GameObject pickupNoti = GameObject.Find("PickUp");
            pickupNoti.GetComponent<UnityEngine.UI.Text>().text = null;
        }
    }
}
