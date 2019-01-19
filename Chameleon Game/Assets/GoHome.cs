using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is on the empty game object HomeBushes and is used to select the random home bush that the player must reach to win the game.
public class GoHome : MonoBehaviour {

    GameObject[] homeBushes;
    GameObject finalHome;
    int index;

    EatBug chameleonFullScript;
    public bool chameleonWins;

    void Start()
    {
        chameleonFullScript = FindObjectOfType<EatBug>();
        chameleonWins = false;
    }

    public GameObject getFinalHome()
    {
        return finalHome;
    }

    //Puts all of the home bushes in the level into an array and randomly selects one
    public void SelectHome()
    {
        homeBushes = GameObject.FindGameObjectsWithTag("Home");

        index = Random.Range(0, homeBushes.Length);
        finalHome = homeBushes[index];
        finalHome.GetComponent<Renderer>().material.color = Color.red;
        Debug.Log("GoHomeScript/SelectHome/" + finalHome.name);
    }

    //Checks to see is the player has arrived at the bush (DOES NOT WORK BECAUSE SCRIPT IS LOCATED ON AN EMPTY GAME OBJECT)
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player1")
        {
            chameleonWins = true;
            Debug.Log("GoHomeScript/SelectHome/Chameleon wins");
        }
    }
}
