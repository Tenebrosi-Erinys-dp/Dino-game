using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballGeneration : MonoBehaviour
{
    public int genrandom;
    public GameObject[] fireball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        genrandom = Random.Range(0, 12000);
        if(genrandom < 20)
        {
            Instantiate(fireball[0], new Vector3(Random.Range(3, 10), 5, 0), Quaternion.identity);
        }
    }
}
