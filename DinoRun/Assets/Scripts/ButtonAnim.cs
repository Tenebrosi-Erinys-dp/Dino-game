/* ButtonAnim.cs
 * By: Alex Dzius
 * Last Edited: 2/10/2020
 * Desc: The code that allows for the animations on each seperate button to be played - respective to each level's player controller
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // play the only animation per object, which is the idle/running animation
      gameObject.GetComponent<Animator>().SetInteger("State", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
