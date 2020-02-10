/* Clouds2.cs
 * By: Alex Dzius
 * Last Edited: 2/10/2020
 * Description: Uses the usual speed translation with specific value adjustments for the cloud's speed in comparison to the rest of the level - in addition displays the animation where needed
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds2 : MonoBehaviour
{
    // get the cloud object
    Rigidbody2D cloud;
    // Start is called before the first frame update
    void Start()
    {
        // get the cloud object
        gameObject.GetComponent<Animator>().SetInteger("State", 0);
        cloud = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // apply the increasing speed to the cloud a 10th of the rate in comparison to the level itself.
        cloud.transform.Translate(Vector2.left * SpeedFromPoints.speed * 0.1f * Time.deltaTime);
    }
}
