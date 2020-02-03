using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacti : MonoBehaviour
{
    public GameObject[] cactees;
    public int random;
    public int genrandom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        genrandom = Random.Range(0, 1000000000);
        if (genrandom < 100)
        {
            random = Random.Range(0, cactees.Length);
            // if a certain condition is given during the generation
            Instantiate(cactees[random], new Vector3(13, -2.25f, 0), Quaternion.identity);
        }
    }
}
