/* SFXRandomContainer.cs
 * By: Nick Erb
 * Last Edited: 2/10/2020
 * Description: Container for the soundeffects and ensures that a random sound effect is played when needed
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFXRandomContainer : MonoBehaviour
{
    AudioSource au;
    public AudioClip[] clips;

    public void Play()
    {
        // get audiosource and play random sound effect every time its called
        au = gameObject.AddComponent<AudioSource>();
        au.clip = clips[Random.Range(0, clips.Length)];
        au.Play();
        // destroy the sound after its over
        Destroy(au, au.clip.length);
    }
}
