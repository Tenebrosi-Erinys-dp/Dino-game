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

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = songFirst;
        source.Play();
        print("Playing");
    }

    private void Update()
    {
        print("Testing if playing");
        if (!source.isPlaying && playing)
        {
            print("Not playing!");
            source.Stop();  
            source.clip = songLoop;
            source.Play();
        }

        if (!playing)
        {
            source.Stop();
        }
    }
}
