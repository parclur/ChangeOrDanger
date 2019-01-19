using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//This script is on the Chameleon gameobject and is used to detect collisions with bugs and to fill the hunger bar
public class EatBug : MonoBehaviour {

    [Header("Chameleon Hunger")]
    public int currentHunger;
    public int maxHunger;
    //public Text hungerLevel;

    public TextMeshProUGUI bugText;

    [Header("Chameleon Full")]
    public bool chameleonIsFull;
    GoHome chooseHomeScript;

    void Start()
    {
        currentHunger = 0;
        maxHunger = 5;

        bugText.text = "Bugs: " + currentHunger + "/" + maxHunger;

        chameleonIsFull = false;
        chooseHomeScript = FindObjectOfType<GoHome>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bug")
        {
            Debug.Log("EatBugScript/OnCollisionEnter/Bug eated");
            currentHunger++;
            bugText.text = "Bugs: " + currentHunger + "/" + maxHunger;
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
        bugText.text = "Get Home!";

        Debug.Log("EatBugScript/ChameleonFull/Full");
        chameleonIsFull = true;
        chooseHomeScript.SelectHome();
    }
}
