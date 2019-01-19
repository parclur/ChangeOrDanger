using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float rotationSpeed = 200.0f;
    [SerializeField] bool isChameleon = false;
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
            transform.Rotate(0, Input.GetAxis("p1_Horizontal") * Time.deltaTime * rotationSpeed, 0);
            transform.Translate(0, 0, -Input.GetAxis("p1_Vertical") * Time.deltaTime * speed);
        
    }
}
