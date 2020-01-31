using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainChunk : MonoBehaviour
{
    public static int destroyPosition = -14;
    public GameController gc;
    // Update is called once per frame
    void Update()
    {
        TestDestroy();
        Move();
    }

    void TestDestroy()
    {
        if(transform.position.x <= destroyPosition)
        {
            gc.Generate();
            Destroy(gameObject); 
        }
    }

    private void Move() {
        Vector3 distance = Vector3.zero;
        distance.x = GameController.speed * Time.deltaTime;
        transform.position -= distance;
    }
}
