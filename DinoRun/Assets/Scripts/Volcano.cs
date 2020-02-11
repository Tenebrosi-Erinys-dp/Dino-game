/*Volcano.cs
 * By: Alex Dzius
 * Last Edited: 2/10/2020
 * Desc: The code that allows for the execution of the volcano animation and parallax effect
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Volcano : MonoBehaviour
{
    public float volspeed;
    Rigidbody2D volcano;
    // Start is called before the first frame update
    void Start()
    {
        // set the volcano animation and object
        gameObject.GetComponent<Animator>().SetInteger("State", 0);
        volcano = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // parallax effect for the volcano based on the current speed on the level
        volspeed = 10 + PointsCalculation.points / 5000f;
        volcano.transform.Translate(Vector2.left * volspeed * 0.03f * Time.deltaTime);
        // teleport the volcano object back if it goes out of the screen
        if(transform.position.x < -8)
        {
            volcano.transform.position = new Vector2(8, transform.position.y);
        }
    }
}
