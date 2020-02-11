/* HitGeneration.cs
 * By: Alex Dzius
 * Last Edited: 2/10/2020
 * Description: Code that generates multiple sprites appearing throughout the game. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGeneration : MonoBehaviour
{
    public GameObject[] cactees;
    public GameObject[] cloud;
    public GameObject[] ptero;
    public int random;
    public int genrandom;
    public int pterorandom;
    public int lastCact;
    public int lastCloud;
    public int lastPtero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // timer each frame for when cactus possible generation
        lastCact++;
        lastCloud++;
        lastPtero++;
        // randomize a large number, and if a certain range inside the number is hit
        genrandom = Random.Range(0, 12000);
        if (genrandom > 50 && genrandom < 140 && lastCact > 125)
        {
            // randomize the type of cactus
            random = Random.Range(0, cactees.Length);
            // spawn the cactus at a given position
            Instantiate(cactees[random], new Vector3(13, -2f, 0), Quaternion.identity);
            // set the timer = 0 at last position
            lastCact = 0;
        }
        if( genrandom < 10 && lastCloud > 2000)
        {
            // spawn the cloud at a given randomized position
            Instantiate(cloud[0], new Vector3(13, (int)Random.Range(0, 4), 0), Quaternion.identity);
            lastCloud = 0;
        }
        if( genrandom > 10 && genrandom < 30 && lastPtero > 400)
        {
            // randomize the y position of the enemy pterodactyl as an int to only have 3 options
            pterorandom = (int)Random.Range(-2, 0);
            // use the previous value to spawn the enermy pterodactyl at a given position
            Instantiate(ptero[0], new Vector3(13, pterorandom+.25f, 0), Quaternion.identity);
            lastPtero = 0;
        }

    }
}
