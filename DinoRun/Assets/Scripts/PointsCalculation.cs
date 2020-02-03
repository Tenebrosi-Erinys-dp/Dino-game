using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCalculation : MonoBehaviour
{
    public float distanceTraveled;
    public static int points;
    Rigidbody2D dummy;
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        dummy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        points = (int) Vector3.Distance(dummy.transform.position, new Vector3(0, -3, 0));
        dummy.transform.Translate(Vector2.left * SpeedFromPoints.speed * Time.deltaTime);

    }
}
