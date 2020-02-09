/* VelocEspeed.cs
 * By: Alex Dzius
 * Last Edited: 2/10/2020
 * Description: Code that allows for the enemy pterodactyls to be at a slightly faster speed than the rest of the map. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocEspeed : MonoBehaviour
{
    public float speed = 10.0f;
    Rigidbody2D ptero;
    // Start is called before the first frame update
    void Start()
    {
        // get the ptero object
        ptero = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // set the speed based on points and then give the object its intended speed at the given frame, slightly faster than the other objects on the map
        speed = 10 + PointsCalculation.points / 5000f;
        ptero.transform.Translate(Vector2.left * speed * 1.25f * Time.deltaTime);
    }
}