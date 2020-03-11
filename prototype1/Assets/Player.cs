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


    [HideInInspector]
    public enum PlayerDirection//indicate the snake's direction with numbers
    {
        LEFT = 0,
        UP = 1,
        RIGHT = 2,
        DOWN = 3,
        COUNT = 4
    } //player direction


    //Variable to determine if the snake is moving 
    [HideInInspector]
    public bool isMoving = true;

    //These variables are used to update the snake's position (refer to Move() for details)
    //public GameObject curBodyPart;
    //public GameObject prevBodyPart;
    public float distance; // Distance between two parts of the snake's body
    public float mindistance = 0.25f; // Min distance between two parts of the snake's body

    //These variables are used to determines the position on which the new body part will be spawn (check Move() for details)
    private List<Vector3> previousPositions; //an ever-growing array that store the positions of the last body part of the snake every frame
    public float lastPosCounter; //the counter variable that helps reset the array every time a certain size is reached

    private List<Vector3> headPositions; //an ever-growing array that store the positions of the snakehead every frame

    private bool addedPart = false;
    int startGameRepetitionCounter = 0;


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
        previousPositions = new List<Vector3>();

        GameObject GlobalPlayer = GameObject.Find("GlobalPlayer");

        int snakeLength = 4;

        nodes.Add(transform.GetChild(0).gameObject);//get the head part

        for (int i = 1; i < snakeLength; i++)
        {
            nodes.Add(GlobalPlayer.transform.GetChild(i).gameObject);//append body part to the nodes array
            previousPositions.Add(nodes[i].transform.position); //store said body part's position to the positions array
        }

        head_Body = nodes[0];//the first child element is the snakehead.
        headPositions = new List<Vector3>();
        headPositions.Add(head_Body.transform.position);

    }

    void Move()
    {
        MovementsInput();

        //retrieve current head position
        Vector3 headPos = head_Body.transform.position;

        //store the head's position into the headPositions list every frame
        headPositions.Add(headPos);

        int frameCounter = 0;

        if (startGameRepetitionCounter >= 15)
        {
            for (int i = 1; i < nodes.Count; i++)
            {
                // Assign each body part's position to the head position 3 frames ago, then 6 frames, and so on....
                nodes[i].transform.position = headPositions[headPositions.Count - frameCounter - 1];
                frameCounter += 3;

                //curBodyPart = nodes[i];
                //prevBodyPart = nodes[i - 1];

                //distance = Vector3.Distance(prevBodyPart.transform.position, curBodyPart.transform.position);
                //Debug.Log(distance);
                //Vector3 newpos = prevBodyPart.transform.position;

                //newpos.y = prevBodyPart.transform.position.y;

                //float T = Time.deltaTime * distance / mindistance * speed;

                //if (T > 0.5f)
                //{
                //T = 0.5f;
                //curBodyPart.transform.position = Vector3.Slerp(curBodyPart.transform.position, newpos, T);
                //curBodyPart.transform.rotation = Quaternion.Slerp(curBodyPart.transform.rotation, prevBodyPart.transform.rotation, T);
                //}

            }
            
        } else
        {
            startGameRepetitionCounter++;
            Debug.Log("adding");
        }

        //Now store the last bodypart's position to the position array
        Vector3 lastBodyPartPos = nodes[nodes.Count - 1].transform.position; //retrieve the last body part's position
        previousPositions.Add(lastBodyPartPos);//append said position to the list


        //Add a body part wherever key Q is pressed
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //Debug.Log("Q pressed");
        //AddBodyPart();
        //}
    }


    public void MovementsInput()
    {
        // Gets the basis of the player's movements
        float z = 0f;//vertical placement
        float x = 0f;

        //old x and z:         
        //float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed; // if there is no horizontal input, x = 0
        //float z = Input.GetAxis("Vertical") * Time.deltaTime * speed; // if there is no vertical input, z = 0

        if (isMoving == true)
        {
            z = 1 * Time.deltaTime * speed;
        }


        // Lets the player move on the planet perfectly in 3D. Without it, the planet would walk on the sphere like its planar.
        transform.Translate(x, 0, z);


        //
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
    }

    public void AddBodyPart()
    {
        //Find the position that the last body part was last on 3 frames ago
        // this variable's value is flawed because it determines the previous node part's position, not the new one's
        Vector3 newPartPos = previousPositions[previousPositions.Count - 4]; //have to account for the first list element being previousPositions[0]

        //Instantiate the new prefab
        GameObject newpart = (Instantiate(tailPrefab, newPartPos, nodes[nodes.Count - 1].transform.rotation));
        
        //Set said object as the Player Object's child
        newpart.transform.SetParent(GameObject.Find("GlobalPlayer").transform);

        newpart.transform.localScale = new Vector3(0.8299207f, 0.8299207f, 0.8299207f);
        
        //Add it to the part's array
        nodes.Add(newpart);
        //Debug.Log(newpart.transform.position);
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

}
