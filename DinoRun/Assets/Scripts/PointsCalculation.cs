/* PointsCalculation.cs
 * By: Alex Dzius
 * Last Edited: 2/10/2020
 * Description: Code that calculates the points of the player, based on the distance travelled by a dummy object. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCalculation : MonoBehaviour
{
    public float distanceTraveled;
    public static int points;
    Rigidbody2D dummy;
    // Start is called before the first frame update
    void Start()
    {
        // set points to 0 based on start and get the rigidbody component
        points = 0;
        dummy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // set the int points based on the distance between the first position and the current position of the dummy
        points = (int) Vector3.Distance(dummy.transform.position, new Vector3(0, -3, 0));
        // give the dummy the same speed as all other objects from the SpeedFromPoints movement
        dummy.transform.Translate(Vector2.left * SpeedFromPoints.speed * Time.deltaTime);

    }
}
