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
    Vector3 moveVector;
    // Use this for initialization
    void Start () {
        player = ReInput.players.GetPlayer(playerId);
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
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
            transform.position += transform.forward * Time.deltaTime * speed;
            //transform.Translate(0, 0, player.GetAxis("Move Vertical") * Time.deltaTime * speed);
            transform.Rotate(0, player.GetAxis("Move Horizontal") * Time.deltaTime * rotationSpeed, 0, Space.World);

        }
        transform.Rotate(-Vector3.left, -player.GetAxis("Move Vertical") * turnSpeed * Time.deltaTime);
        rb.freezeRotation = true;
    }
}
