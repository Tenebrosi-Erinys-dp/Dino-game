using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGeneration : MonoBehaviour
{
    public GameObject[] cactees;
    public GameObject[] cloud;
    public GameObject[] veloc;
    public int random;
    public int genrandom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        genrandom = Random.Range(0, 12000);
        if (genrandom < 100)
        {
            random = Random.Range(0, cactees.Length);
            // if a certain condition is given during the generation
            Instantiate(cactees[random], new Vector3(13, -2.25f, 0), Quaternion.identity);
        }
        if( genrandom < 10)
        {
            Instantiate(cloud[0], new Vector3(13, (int)Random.Range(0, 4), 0), Quaternion.identity);
        }
        if(genrandom > 10 && genrandom < 30)
        {
            Instantiate(veloc[0], new Vector3(13, (int)Random.Range(0, 4), 0), Quaternion.identity);
        }

    }
}
