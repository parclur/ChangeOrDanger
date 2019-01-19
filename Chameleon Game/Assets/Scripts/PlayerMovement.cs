using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerMovement : MonoBehaviour
{
    public int playerId = 0;
    private Player player;
    Vector3 moveVector;
    [SerializeField] float speed = 5.0f;
    [SerializeField] float rotationSpeed = 200.0f;
    [SerializeField] bool isChameleon = false;
    Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        player = ReInput.players.GetPlayer(playerId);
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (moveVector.x != 0.0f || moveVector.y != 0.0f)
        {
            transform.Translate(0, 0, player.GetAxis("Move Vertical") * Time.deltaTime * speed);
            transform.Rotate(0, player.GetAxis("Move Horizontal") * Time.deltaTime * rotationSpeed, 0);
        }

    }
}
