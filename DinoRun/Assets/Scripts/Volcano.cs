/*Volcano.cs
 * By: Alex Dzius
 * Last Edited: 2/10/2020
 * Desc: The code that allows for the execution of the volcano animation.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volcano : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().SetInteger("State", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
