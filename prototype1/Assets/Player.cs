/*****************

Planet Spherical Gravity (Multiple Planets) - Part 1
by SawneyStudios on YouTube and modified by me

https://www.youtube.com/watch?v=UeqfHkfPNh4

******************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Planet;
    // These two floats can be changed in Unity also
    public float speed = 7;
    public float JumpHeight = 7f;

    // Related to the base gravity script that we do not need to modify.
    float gravity = 100;
    bool OnGround = false;
    float distanceToGround;
    Vector3 Groundnormal;

    // Gets the player's RigidBody. It needs a RigidBody installed on it in order to work.
    private Rigidbody rb;

    /*********************SNEK VARIABLES**************************/
    /*********************SNEK VARIABLES**************************/
    /*********************SNEK VARIABLES**************************/

    [SerializeField] //opposite to hideininspector
    private GameObject tailPrefab; //add this prefab to the snake when it eats the fruit

    private GameObject head_Body; //the GameObject corresponding to the head (it's the robot character for the moment)

    private List<GameObject> nodes; //every part of the snake's body

    private bool create_Node_At_Tail; //to tell if you need to add tail or not

    [HideInInspector]
    public enum PlayerDirection//indicate the snake's direction with numbers
    {
        LEFT = 0,
        UP = 1,
        RIGHT = 2,
        DOWN = 3,
        COUNT = 4
    } //player direction

    [HideInInspector] //hide the variable from the inspector
    public PlayerDirection directionH;
    [HideInInspector] //hide the variable from the inspector
    public PlayerDirection directionV;

    public GameObject curBodyPart;
    public GameObject prevBodyPart;
    public float distance;
    public float mindistance = 0.25f;

    /*******************END SNEK VARIABLES************************/
    /*******************END SNEK VARIABLES************************/
    /*******************END SNEK VARIABLES************************/

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Precaution to take for bugs by constraining the player's Rigidbody rotation
        rb.freezeRotation = true;

        InitSnakeNodes();//set up the snake
        InitPlayer();//set up the snake's parts' placement according to the snake's direction
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();



        // These next parts of the Update() function does not have to be modified, its the base of the gravity for the items that hold this script
        GroundControl();
        GravityAndRotation();


    }

    void InitSnakeNodes()//get all the snake parts
    {
        nodes = new List<GameObject>();//Store all of them into the nodes list

        nodes.Add(transform.GetChild(0).gameObject);//child index 0 of the GameObject
        nodes.Add(transform.GetChild(1).gameObject);

        head_Body = nodes[0];//the first child element is the snakehead.
        for(int i=1; i<3; i++)
        {
            AddBodyPart();
        }

    }

    void InitPlayer()
    {

    }

    void Move()
    {
        // Gets the basis of the player's movements
        float x = 0f;//horizontal placement
        float z = 0f;//vertical placement

        //old x and z:         
        //float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed; // if there is no horizontal input, x = 0
        //float z = Input.GetAxis("Vertical") * Time.deltaTime * speed; // if there is no vertical input, z = 0

        directionH = PlayerDirection.RIGHT;
        directionV = PlayerDirection.UP;

        switch (directionH)
        {
            case PlayerDirection.RIGHT:
                x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
                break;

            case PlayerDirection.LEFT:
                x = -1 * Time.deltaTime * speed;
                break;
        }

        switch (directionV)
        {
            case PlayerDirection.UP:
                z = 1 * Time.deltaTime * speed;
                Debug.Log("directionV");
                break;

            case PlayerDirection.DOWN:
                z = -1 * Time.deltaTime * speed;
                break;
        }

        Vector3 parentPos = head_Body.transform.position;//take head's position as the first parent position
        Vector3 prevPosition;//variable for preceding node's position. Created so that changes will not affect the value of parentPos.

        // Lets the player move on the planet perfectly in 3D. Without it, the planet would walk on the sphere like its planar.
        transform.Translate(x, 0, z);
        // update the snake's global position
        //rb.transform.position = head_Body.transform.position;

        //
        // Player inputs by rotation. Can be changed to translation I think because as the prototype is now, the player cannot move left or right without moving foward or backyard also.
        // Change character direction by rotation: doesn't actually move the character around (as it affects the y axis) but rather the rotation range
        // If the 'D' key or RightArrow is pressed
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // The only thing modifiable in this string is the number '150'. Going higher will make the player's avatar will do a bigger rotation while smaller will to the opposite.
            transform.Rotate(0, 150 * Time.deltaTime, 0);
        }
        // If the 'A' key or LeftArrow is pressed
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // The only thing modifiable in this string is the number '-150'. Going higher will make the player's avatar will do a bigger rotation while smaller will to the opposite.
            // Makes sures the inputs gets the same number or the movements will be unbalanced.
            transform.Rotate(0, -150 * Time.deltaTime, 0);
        }

        for (int i = 1; i < nodes.Count; i++)
        {
            curBodyPart = nodes[i];
            prevBodyPart = nodes[i - 1];

            //distance = Vector3.Distance(prevBodyPart.transform.position, curBodyPart.transform.position);
            //Debug.Log(distance);
            Vector3 newpos = prevBodyPart.transform.position;

            //newpos.y = prevBodyPart.transform.position.y;

            float T = Time.deltaTime * distance / mindistance * speed;

            if (T>0.5f)
            {
                T = 0.5f;
                curBodyPart.transform.position = Vector3.Slerp(curBodyPart.transform.position, newpos, T);
                curBodyPart.transform.rotation = Quaternion.Slerp(curBodyPart.transform.rotation, prevBodyPart.transform.rotation, T);
            }

            //prevPosition = nodes[i].transform.position;//the current node's position become the next previous position

            //nodes[i].transform.position = parentPos;//the current node takes on the parent position...
            //Debug.Log(i + "position" + nodes[i].transform.position);
            //parentPos = prevPosition;//...and its position becomes the next parent position
        }

        //AddBodyPart();
    }

    public void AddBodyPart()
    {
        GameObject newpart = (Instantiate(tailPrefab, nodes[nodes.Count - 1].transform.position, nodes[nodes.Count - 1].transform.rotation));
        newpart.transform.SetParent(transform,true);
        nodes.Add(newpart);
        Debug.Log(newpart.transform.position);
    }

    void GroundControl()
    {
        // Ground control
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
        {
            distanceToGround = hit.distance;
            Groundnormal = hit.normal;

            if (distanceToGround <= 0.1f)
            {
                OnGround = true;
            }
            else
            {
                OnGround = false;
            }
        }
    }

    void GravityAndRotation()
    {
        // Gravity and rotation
        Vector3 gravDirection = (transform.position - Planet.transform.position).normalized;

        if (OnGround == false)
        {
            rb.AddForce(gravDirection * -gravity);
        }

        //

        Quaternion toRotation = Quaternion.FromToRotation(transform.up, Groundnormal) * transform.rotation;
        transform.rotation = toRotation;
    }

    // Jump (modified by me, so the player can't spam the jump button and go in space, thus broken the game)
    public void OnCollisionStay(Collision other)
    {
        // The player can only jump again if he touches the planet
        if (other.gameObject == Planet)
        {
            // If the 'Space' key is pressed
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(transform.up * 5000 * JumpHeight * Time.deltaTime);
            }
        }
    }
}
