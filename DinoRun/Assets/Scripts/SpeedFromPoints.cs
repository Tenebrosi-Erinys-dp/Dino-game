using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedFromPoints : MonoBehaviour
{
    public static float speed;
    Rigidbody2D Chunk;
    // Start is called before the first frame update
    void Start()
    {
        Chunk = GetComponent<Rigidbody2D>();
        speed = 10.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // calculate the speed via the points & display animation if needed
        speed = CalculateSpeed(PointsCalculation.points);
        // use that speed to make the actual speed 
        Chunk.transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    float CalculateSpeed(float p)
    {
        if(p % 50 == 0)
        {
            speed = speed + (0.5f * speed);
        }
        
        // TODO display animation of text
        if(p % 100 == 0)
        {
            // display animation
            // present sound
        }
        return speed;
    }
}
