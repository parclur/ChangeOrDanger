﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float rotationSpeed = 200.0f;

    Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, Input.GetAxis("p1_Horizontal") * Time.deltaTime * rotationSpeed, 0);
            transform.Translate(0, 0, Input.GetAxis("p1_Vertical") * Time.deltaTime * speed);
        }

    }
}
