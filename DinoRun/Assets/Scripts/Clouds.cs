using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    Rigidbody2D objects;
    // Start is called before the first frame update
    void Start()
    {
        objects = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        objects.transform.Translate(Vector2.left * SpeedFromPoints.speed * 0.1f * Time.deltaTime);
    }
}
