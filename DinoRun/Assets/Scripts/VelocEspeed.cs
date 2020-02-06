using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocEspeed : MonoBehaviour
{
    public float speed = 10.0f;
    Rigidbody2D Chunk;
    // Start is called before the first frame update
    void Start()
    {
        Chunk = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = 10 + PointsCalculation.points / 5000f;
        Chunk.transform.Translate(Vector2.left * speed * 1.25f * Time.deltaTime);
        print(speed);
    }
}