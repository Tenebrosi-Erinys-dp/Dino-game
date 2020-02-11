/* FireballGeneration.cs
 * By: Alex Dzius
 * Last Edited: 2/10/2020
 * Description: Code that generates the fireballs at given randomized time and position.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballGeneration : MonoBehaviour
{
    public int genrandom;
    public int lastBall;
    public GameObject[] fireball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // counter per frame to prevent from overspawning objects
        lastBall++;
        // generate a large number, and if a small range of numbers is hit and there wasnt a fireball recently, generate a fireball in a randomized position.
        genrandom = Random.Range(0, 12000);
        if(genrandom < 20 && lastBall > 100)
        {
            Instantiate(fireball[0], new Vector3(Random.Range(3, 10), 5, 0), Quaternion.identity);
            // set the time from last ball to 0
            lastBall = 0;
        }
    }
}
