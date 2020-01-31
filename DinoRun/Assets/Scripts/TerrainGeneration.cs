using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    public GameObject[] chunks;
    public int random;

    // Start is called before the first frame update
    void Start()
    {
       
    }
       
    // Update is called once per frame
    void Update()
    {
       generateTerrain();
    }
    void generateTerrain()
    {
        random = Random.Range(1, chunks.Length - 1);
        Instantiate(chunks[random], new Vector3(14, -3, 0), Quaternion.identity);
    }
}
