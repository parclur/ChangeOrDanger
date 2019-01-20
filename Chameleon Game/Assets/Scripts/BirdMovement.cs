using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

//[RequireComponent(typeof(CharacterController))]
public class BirdMovement : MonoBehaviour {
    Rigidbody rb;
    public int playerId = 1;
    private Player player;
    [SerializeField] float speed = 5.0f;
    [SerializeField] float rotationSpeed = 200.0f;
    [SerializeField] float turnSpeed = 50.0f;
    [SerializeField] bool isChameleon = false;
    private int downwardsForce = 500;
    public Vector3 gravityForce = new Vector3(0f, -9.8f, 0f);
    Vector3 moveVector;
    bool canMove;
    // Use this for initialization
    void Start () {
        player = ReInput.players.GetPlayer(playerId);
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        canMove = true;
    }


    // Update is called once per frame
    void Update () {
        GetInput();
        ProcessInput();
    }

    void GetInput()
    {
        moveVector.x = player.GetAxis("Move Horizontal");
        moveVector.y = player.GetAxis("Move Vertical");
    }

    void ProcessInput()
    {
        
        if (!isChameleon)
        {
            if (canMove)
            {
                transform.position += transform.forward * Time.deltaTime * speed;

                transform.Rotate(-Vector3.left, -player.GetAxis("Move Vertical") * turnSpeed * Time.deltaTime);
            }
            transform.Rotate(0, player.GetAxis("Move Horizontal") * Time.deltaTime * rotationSpeed, 0, Space.World);

        }
        if (player.GetButtonDown("P1 A Button"))
        {
            canMove = true;
        }
        }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Home")
        {
            canMove = false;
            rb.AddForce(transform.TransformDirection(gravityForce) * Time.deltaTime * downwardsForce, ForceMode.Acceleration);
        }
        
    }
}
