/* DebugKeys.cs
 * By: Alex Dzius
 * Last Edited: 2/10/2020
 * Description: A collection of code that allows for easier debugging process throughout the level.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DebugKeys : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if key r is pressed
        if (Input.GetKey("r"))
        {
            // reset back to loading screen
            SceneManager.LoadScene("TitleScreen");
        }
        // if space is pressed
        if (Input.GetKey("space"))
        {
            // test the "time stop" function - basically pausing
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
        }
    }
}
