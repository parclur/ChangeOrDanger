using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public bool isChameleon = false;

    public float horRotationSpeed = 1f;
    public float vertRotationSpeed = 1f;

    float xAxis;
    float yAxis;

    GameObject cameraRoot;

	// Use this for initialization
	void Start () {
        cameraRoot = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        //Used so that we only need one script for player cameras
        if (isChameleon)
        {
            //Getting input
            xAxis = Input.GetAxis("p1_Joystick_Move_H");
            yAxis = Input.GetAxis("p1_Joystick_Move_V");

            //Rotate camera around cameraRoot
            cameraRoot.transform.Rotate(0, xAxis * horRotationSpeed, 0);
            cameraRoot.transform.Rotate(yAxis * vertRotationSpeed, 0, 0);

            //Set the xAxis value to the current local Euler angle of X (0 - 360)
            xAxis = cameraRoot.transform.localEulerAngles.x;

            //Since Euler angles don't take negatives for some ungodly reason, heres some 
            //stupid code to make sure the player can't get to the poles of the camera rotation.
            //Also prevents the player from looking through the floor. In the future place a 
            //physics object (or fancy shader for the ground) on the camera so it can't clip through 
            if (xAxis < 325)
                xAxis = 325;
            else if (xAxis > 350)
                xAxis = 350;

            //set the local euler angles of the camera root to the angles used above, with 0 in the Z axis
            cameraRoot.transform.localEulerAngles = new Vector3(xAxis, cameraRoot.transform.localEulerAngles.y, 0);
        }
        else
        {
            //Getting input
            xAxis = Input.GetAxis("p2_Joystick_Move_H");
            yAxis = Input.GetAxis("p2_Joystick_Move_V");

            //Rotate camera around cameraRoot
            cameraRoot.transform.Rotate(0, xAxis * horRotationSpeed, 0);
            cameraRoot.transform.Rotate(yAxis * vertRotationSpeed, 0, 0);

            //Set the xAxis value to the current local Euler angle of X (0 - 360)
            xAxis = cameraRoot.transform.localEulerAngles.x;

            //Since Euler angles don't take negatives for some ungodly reason, heres some 
            //stupid code to make sure the player can't get to the poles of the camera rotation.
            //Also prevents the player from looking through the floor. In the future place a 
            //physics object (or fancy shader for the ground) on the camera so it can't clip through 
            if (xAxis < 325)
                xAxis = 325;
            else if (xAxis > 350)
                xAxis = 350;

            //set the local euler angles of the camera root to the angles used above, with 0 in the Z axis
            cameraRoot.transform.localEulerAngles = new Vector3(xAxis, cameraRoot.transform.localEulerAngles.y, 0);
        }
    }
}
