/* Every100Points.cs
 * By: Alex Dzius
 * Last Edited: 2/10/2020
 * Description: Code that allows the disabling of the object at the start, to allow the flashing in itself
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Every100Points : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // deactivares the square at the start
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
