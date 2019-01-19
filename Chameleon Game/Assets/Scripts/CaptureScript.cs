using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CaptureScript : MonoBehaviour {

    TextMeshProUGUI text;
	// Use this for initialization
	void Start () {
        text = GameObject.FindGameObjectWithTag("Player2Win").GetComponent<TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player1")
        {
            Debug.Log("Caught!");
            Destroy(collision.gameObject);
            text.enabled = true;
            Time.timeScale = 0.0f;
        }
    }
}
