using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour {
    [SerializeField] float speed = 5.0f;
    [SerializeField] float rotationSpeed = 200.0f;
    [SerializeField] float turnSpeed = 50.0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * Time.deltaTime * speed;
        if ( Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, Input.GetAxis("p2_Horizontal") * Time.deltaTime * rotationSpeed, 0, Space.World);
            
            //transform.Translate(0, 0, Input.GetAxis("p2_Vertical") * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Hitting");
            transform.Rotate(-Vector3.left, turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("Hitting");
            transform.Rotate(Vector3.left, turnSpeed * Time.deltaTime);
        }
    }
}
