using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class ColorChanging : MonoBehaviour {
    Renderer playerMat;
    private Player player;
    public int playerId = 0;

    // Use this for initialization
    void Start () {
        player = ReInput.players.GetPlayer(playerId);
        playerMat = GetComponent<Renderer>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionStay(Collision col)
    {

        if(player.GetButtonDown("P1 A Button"))
        {
            Debug.Log("Im being pressed");
            playerMat.material = col.gameObject.GetComponent<Renderer>().material;
        }
    }
   
}
