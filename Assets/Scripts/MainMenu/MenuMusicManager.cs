using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicManager : MonoBehaviour
{

    AudioSource auso;

    public AudioClip baseAudio;
    public AudioClip extendAudio;


    void Start()
    {
        auso = GetComponent<AudioSource>();
        SetBaseAudio();


    }

    void Update()
    {
        
    }

    public void SetBaseAudio()
    {
        PlayAudioClip(baseAudio);
    }

    public void SetExtendAudio()
    {
        PlayAudioClip(extendAudio);
    }

    public void PlayAudioClip(AudioClip ac)
    {
        auso.Stop();

        auso.playOnAwake = true;
        auso.loop = true;

        auso.clip = ac;
        auso.time = 0;

        auso.Play();
    }
}
