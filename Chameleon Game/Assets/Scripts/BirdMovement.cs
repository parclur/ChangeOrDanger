using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour {
    Rigidbody rb;
    [SerializeField] float speed = 5.0f;
    [SerializeField] float rotationSpeed = 200.0f;
    [SerializeField] float turnSpeed = 50.0f;
    [SerializeField] bool isChameleon = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * Time.deltaTime * speed;
        if (!isChameleon)
        {
            transform.Rotate(0, Input.GetAxis("p2_Horizontal") * Time.deltaTime * rotationSpeed, 0, Space.World);

            //transform.Translate(0, 0, Input.GetAxis("p2_Vertical") * Time.deltaTime * speed);
        }
        transform.Rotate(-Vector3.left, -Input.GetAxis("p2_Vertical") * turnSpeed * Time.deltaTime);

        rb.freezeRotation = true;
    }
}
