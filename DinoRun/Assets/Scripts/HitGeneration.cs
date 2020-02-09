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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // randomize a large number, and if a certain range inside the number is hit
        genrandom = Random.Range(0, 12000);
        if (genrandom > 50 && genrandom < 140)
        {
            // randomize the type of cactus
            random = Random.Range(0, cactees.Length);
            // spawn the cactus at a given position
            Instantiate(cactees[random], new Vector3(13, -1.75f, 0), Quaternion.identity);
        }
        if( genrandom < 10)
        {
            // spawn the cloud at a given randomized position
            Instantiate(cloud[0], new Vector3(13, (int)Random.Range(0, 4), 0), Quaternion.identity);
        }
        if( genrandom > 10 && genrandom < 30)
        {
            // randomize the y position of the enemy pterodactyl as an int to only have 3 options
            pterorandom = (int)Random.Range(-2, 0);
            // use the previous value to spawn the enermy pterodactyl at a given position
            Instantiate(ptero[0], new Vector3(13, pterorandom+.25f, 0), Quaternion.identity);
        }

    }
}
