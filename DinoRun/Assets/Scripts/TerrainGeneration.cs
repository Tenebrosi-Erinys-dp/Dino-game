/* TerrainGeneration.cs
 * By: Alex Dzius
 * Last Edited: 2/10/2020
 * Description: Code that allows the generation of the chunks throughout the level, making sure that theres a constant supply of floor
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    public GameObject[] chunks;
    public int random;
    public int layermask = 1 << 1;
    // Start is called before the first frame update
    void Start()
    {
       
    }
       
    // Update is called once per frame
    void Update()
    {
        // randomize the type of chunk to be spawned
        random = Random.Range(0, chunks.Length);
        // call a raycast to check if given position is empty
        RaycastHit2D hit = Physics2D.Linecast(new Vector3(7.9999999f, -3f, 0), new Vector3(8, -3f, 0), layermask);
        // if so
        if(hit.collider == false)
        {
            // generate terrain with the randomized chunk
            generateTerrain(random);
        }
       
    }
    void generateTerrain(int random)
    {
        // generate the randomized chunk 
        Instantiate(chunks[random], new Vector3(12.85f, -3.3f, 0), Quaternion.identity);
    }
}
