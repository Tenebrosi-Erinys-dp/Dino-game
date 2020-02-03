﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    Rigidbody2D cloud;
    int point2 = (int)PointsCalculation.points;
    // Start is called before the first frame update
    void Start()
    {
        cloud = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        cloud.transform.Translate(Vector2.left * SpeedFromPoints.speed * 0.1f * Time.deltaTime);
        Instantiate(cloud, new Vector3(13, 1, 0), Quaternion.identity);
    }
}
