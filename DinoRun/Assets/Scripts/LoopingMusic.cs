    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LoopingMusic : MonoBehaviour
{
    AudioSource source;
    public AudioClip songFirst;
    public AudioClip songLoop;
    public bool playing = true;
    public bool startScenePlaying;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = songFirst;
        if (startScenePlaying)
        {
            source.Play();
        }
    }

    private void Update()
    {
        if (!source.isPlaying && playing)
        {
            source.Stop();  
            source.clip = songLoop;
            source.Play();
        }

        if (!playing || !startScenePlaying)
        {
            source.Stop();
        }
    }

    public void Begin()
    {
        if (!startScenePlaying)
        {
            source.Play();
        }
        startScenePlaying = true;
    }

    public void Stop()
    {
        startScenePlaying = false;
        source.Stop();
    }
}
