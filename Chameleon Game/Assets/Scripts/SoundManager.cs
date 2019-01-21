using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [Header("Sound Sources")]
    public AudioSource source0;
    public AudioSource source1;
    public AudioSource source2;
    public AudioSource source3;
    public AudioSource source4;

    [Header("Sound Clips")]
    public AudioClip music; //Background Music
    public AudioClip chameleonTongue;
    public AudioClip flyBuzzing;

    void Start()
    {
        //Used if we want to make the SoundManager a singleton
        /*
        if (Instance == null)
        {
            Instance = this;
        }

        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        */

        PlayMusic();
    }

    void Update()
    {

    }

    public void StopSounds()
    {
        source1.Stop();
        source2.Stop();
        //source3.Stop();
        //source4.Stop();
    }

    public void PlayMusic()
    {
        source0.clip = music;
        source0.Play();
    }

    public void PlayChameleonTongue()
    {
        source1.clip = chameleonTongue;
        source1.Play();
    }

    public void PlayFlyBuzzing()
    {
        source2.clip = flyBuzzing;
        source2.Play();
    }

    public void StopFlyBuzzing()
    {
        source2.Stop();
    }

    public void FlyBuzzingVolume(float volume)
    {
        source2.volume = volume;
    }
}
