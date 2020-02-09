/* FireballDestroy.cs
 * By: Alex Dzius
 * Last Edited: 2/10/2020
 * Description: Slightly adjusted code to DestroyIfPast, adjusted destruction place as they move at a different trajectory to the rest of the map.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballDestroy : MonoBehaviour
{
    Rigidbody2D fireball;
    // Start is called before the first frame update
    void Start()
    {
        // get the fireball rigidbody
        fireball = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if past the given axis
        if (transform.position.y < -1.5f)
        {
            // destroy the object
            Destroy(gameObject);
        }
    }
}
