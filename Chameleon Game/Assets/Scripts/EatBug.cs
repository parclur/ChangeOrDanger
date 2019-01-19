using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script is on the Chameleon gameobject and is used to detect collisions with bugs and to fill the hunger bar
public class EatBug : MonoBehaviour {

    [Header("Chameleon Hunger")]
    public int currentHunger;
    public int maxHunger;
    //public Text hungerLevel;

    [Header("Chameleon Full")]
    public bool chameleonIsFull;
    GoHome chooseHomeScript;

    void Start()
    {
        currentHunger = 0;
        maxHunger = 5;

        chameleonIsFull = false;
        chooseHomeScript = FindObjectOfType<GoHome>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bug")
        {
            Debug.Log("EatBugScript/OnCollisionEnter/Bug eated");
            currentHunger++;
            Destroy(collision.gameObject);
            //hungerLevel.text = currentHunger.ToString() + "/" + maxHunger.ToString();

            if(currentHunger == maxHunger)
            {
                ChameleonFull();
            }
        }
    }

    public void ChameleonFull()
    {
        Debug.Log("EatBugScript/ChameleonFull/Full");
        chameleonIsFull = true;
        chooseHomeScript.SelectHome();
    }
}
