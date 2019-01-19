using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBush : MonoBehaviour {

    GoHome chooseHomeScript;
    GameObject thisHomeBush;

    public bool chameleonWins;

    void Start()
    {
        chooseHomeScript = FindObjectOfType<GoHome>();
        thisHomeBush = this.gameObject;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player1")
        {
            if(thisHomeBush == chooseHomeScript.getFinalHome())
            {
                chameleonWins = true;
                Debug.Log("HomeBushScript/OnCollisionEnter/Chameleon wins");
            }
        }
    }

    GameObject checkIfFinalHome()
    {
        return this.gameObject;
    }
}
