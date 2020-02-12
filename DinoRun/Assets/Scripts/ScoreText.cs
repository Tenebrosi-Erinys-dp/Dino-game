/* ScoreText.cs
 * By: Alex Dzius
 * Last Edited: 2/10/2020
 * Description: Code that allows the constant display of the score at any given time, and formats it correcly throughout the level.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    TextMesh scoretext;
    // Start is called before the first frame update
    void Start()
    {
        // get the score component and format the display of it correctly
        scoretext = GetComponent<TextMesh>();
        scoretext.text = 00000.ToString();
    }
    // give outside objects an easy way to update if needed as a seperate function to update
    public void UpdateScore()
    {
        // constantly update the scoretext based on the current points
        scoretext.text = PointsCalculation.points.ToString("00000");
    }

    // Update is called once per frame
    void Update()
    {
        // update score
        UpdateScore();
    }
}
