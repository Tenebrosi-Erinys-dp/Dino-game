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
        random = Random.Range(0, chunks.Length);
        print(random);
        // FIX SMALL GAPS INSERTION
        RaycastHit2D hit = Physics2D.Linecast(new Vector3(6.9999999f, -3, 0), new Vector3(7, -3, 0), layermask);
        if(hit.collider == false)
        {
            generateTerrain(random);
        }
       
    }
    void generateTerrain(int random)
    {
        print(random);
        Instantiate(chunks[random], new Vector3(13, -3, 0), Quaternion.identity);
    }
}
