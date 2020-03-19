using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "EnemyBall")
        {
            //Decrease the ball's velocity
            Vector2 v = col.gameObject.GetComponent<Rigidbody>().velocity;
            v = v.normalized;
            v *= 8f;
            col.gameObject.GetComponent<Rigidbody>().velocity = v;

            //Decrease the boucing effect of the ball
            col.gameObject.GetComponent<SphereCollider>().material.bounciness = 0.7f;

            //Lose the ball's "killable status"
            //col.gameObject.tag = "PickableBall";

            //Change tag for the current ball
            if (col.gameObject.GetComponent<Renderer>().material.color == Color.red)
            {
                col.gameObject.tag = "PickableRed";
            }
            if (col.gameObject.GetComponent<Renderer>().material.color == Color.cyan)
            {
                col.gameObject.tag = "PickableCyan";
            }
            if (col.gameObject.GetComponent<Renderer>().material.color == Color.green)
            {
                col.gameObject.tag = "PickableGreen";
            }
        }
    }
}
