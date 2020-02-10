/* DestroyIfPast.cs
 * By: Alex Dzius
 * Last Edited: 2/10/2020
 * Description: Code that allows for the destruction of an object after being past a certain x value, to ensure that the game will not have too much objects loaded.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfPast : MonoBehaviour
{
    Rigidbody2D myRB;
    // Start is called before the first frame update
    void Start()
    {
        // get the object for the destruction
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // once past the given x value, which is outside of the screen
        if(transform.position.x < -13)
        {
            // destroy the entire gameobject
            Destroy(gameObject);
        }
    }
}
