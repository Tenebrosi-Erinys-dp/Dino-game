/* SpeedFromPoints.cs
 * By: Alex Dzius
 * Last Edited: 2/10/2020
 * Description: Code that allows for the proper speed of each object at a given time based on the total points of the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedFromPoints : MonoBehaviour
{
    public static float speed = 10.0f;
    Rigidbody2D MovObject;
    // Start is called before the first frame update
    void Start()
    {
        // get the object thats to be moved
        MovObject = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // set the speed value based on points
        speed = 10 + PointsCalculation.points / 5000f;
        // move the object based on speed
        MovObject.transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
