using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGeneration: MonoBehaviour
{
    public GameObject[] cactees;
    public GameObject[] cloud;
    public int random;
    public int genrandom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        genrandom = Random.Range(0, 3000);
        if (genrandom < 10)
        {
            random = Random.Range(0, cactees.Length);
            // if a certain condition is given during the generation
            Instantiate(cactees[random], new Vector3(13, -2.25f, 0), Quaternion.identity);
        }
        if( genrandom < 1)
        {
            Instantiate(cloud[0], new Vector3(13, (int)Random.Range(0, 4), 0), Quaternion.identity);
        }

    }
}
