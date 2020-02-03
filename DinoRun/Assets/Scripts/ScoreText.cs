﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    TextMesh myTM;
    // Start is called before the first frame update
    void Start()
    {
        myTM = GetComponent<TextMesh>();
        myTM.text = 0.ToString();
    }
    // give outside objects an easy way to update
    public void UpdateScore()
    {
        myTM.text = PointsCalculation.points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }
}