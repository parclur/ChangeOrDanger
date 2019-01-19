using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanging : MonoBehaviour {
    Renderer playerMat;
	// Use this for initialization
	void Start () {
        playerMat = GetComponent<Renderer>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionStay(Collision col)
    {

        if(Input.GetButtonDown("p1_Joystick_Button_A"))
        {
            Debug.Log("Im being pressed");
            playerMat.material = col.gameObject.GetComponent<Renderer>().material;
        }
    }
   
}
