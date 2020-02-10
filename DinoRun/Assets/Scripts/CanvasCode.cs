/* CanvasCode.cs
 * By: Alex Dzius
 * Last Edited: 2/10/2020
 * Description: Deactivates the Death Screen Canvas every time any Scene is loaded.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //deactivates the canvas on start
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
