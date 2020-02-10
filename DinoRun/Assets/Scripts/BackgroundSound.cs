/* BackgroundSound.cs
 * By: Alex Dzius
 * Last Edited: 2/10/2020
 * Desc: The code that allows for the background music to be played.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSound : MonoBehaviour
{
    AudioSource background;
    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<AudioSource>();
        background.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(VelocMove.hit == true || PterodactylMovement.hit2 == true)
        {
            background.Stop();
        }
    }
}
