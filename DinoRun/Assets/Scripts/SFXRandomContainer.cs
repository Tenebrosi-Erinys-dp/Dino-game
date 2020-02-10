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
        au = gameObject.AddComponent<AudioSource>();
        au.clip = clips[Random.Range(0, clips.Length)];
        au.Play();
        Destroy(au, au.clip.length);
    }
}
