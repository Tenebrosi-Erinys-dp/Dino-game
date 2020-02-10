/* HighScore.cs
 * By: Alex Dzius
 * Last Edited: 2/10/2020
 * Description: Code that displays the highscore in the right position, and uses the stored value to always display the highscore.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScore : MonoBehaviour
{
    Text HSText;
    // Start is called before the first frame update
    void Start()
    {
        // get the text component and start it with right formatting
        HSText = GetComponent<Text>();
        HSText.text = 00000.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // set the text to the current highscore
        HSText.text = "HI: " + DinoMovement.highscore.ToString("00000");
    }
}
