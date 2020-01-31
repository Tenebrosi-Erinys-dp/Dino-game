using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// FIX GAMEOBJECT ACCESSING
public class DestroyIfPast : MonoBehaviour
{
    Rigidbody2D myRB;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(myRB.transform.position.x < -10)
        {
            Destroy(myRB);
        }
    }
}
