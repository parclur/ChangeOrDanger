using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugInfo : MonoBehaviour {

    SoundManager soundManagerScript;

    public Transform playerObject;
    float playerDistance;
    float newVolume;

    void Start()
    {
        soundManagerScript = FindObjectOfType<SoundManager>();
    }

    void Update()
    {
        CalculateVolume();
    }

    void CalculateVolume()
    {
        playerDistance = Vector3.Distance(playerObject.position, transform.position);

        if (playerDistance <= 5f && playerDistance >= -5f)
        {
            Debug.Log("BugInfoScript/CalculateVolume/Fly is close");
            newVolume = playerDistance / 5;
            soundManagerScript.PlayFlyBuzzing();
            soundManagerScript.FlyBuzzingVolume(newVolume);
        }
        else
        {
            soundManagerScript.StopFlyBuzzing();
        }
    }
}
