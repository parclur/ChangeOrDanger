using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HomeBush : MonoBehaviour {
    TextMeshProUGUI text;

    GoHome chooseHomeScript;
    GameObject thisHomeBush;

    public bool chameleonWins;

    void Start()
    {
        text = GameObject.FindGameObjectWithTag("PlayerWinsText").GetComponent<TextMeshProUGUI>();

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
                text.enabled = true;
                Time.timeScale = 0.0f;
                Debug.Log("HomeBushScript/OnCollisionEnter/Chameleon wins");
            }
        }
    }

    GameObject checkIfFinalHome()
    {
        return this.gameObject;
    }
}
