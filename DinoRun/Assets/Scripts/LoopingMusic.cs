/* FireballDestroy.cs
 * By: Nick Erb
 * Last Edited: 2/10/2020
 * Description: Music controller for the background music, to ensure all music can be stopped and played whenever needed.
 */
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
        // get the audio and start playing the scene if given permission
        source = GetComponent<AudioSource>();
        source.clip = songFirst;
        if (startScenePlaying)
        {
            source.Play();
        }
    }

    private void Update()
    {
        // if source isnt playing start the loop
        if (!source.isPlaying && playing)
        {
            source.Stop();  
            source.clip = songLoop;
            source.Play();
        }
        // if neither the source or anything is playing, then just stop all
        if (!playing || !startScenePlaying)
        {
            source.Stop();
        }
    }

    public void Begin()
    {
        // if sounds didnt start yet then start playing
        if (!startScenePlaying)
        {
            source.Play();
        }
        startScenePlaying = true;
    }

    public void Stop()
    {
        // if scene is being stopped, set playing to false and stop audio.
        startScenePlaying = false;
        source.Stop();
    }
}
