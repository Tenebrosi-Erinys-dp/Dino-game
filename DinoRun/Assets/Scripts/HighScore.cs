using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScore : MonoBehaviour
{
    Text myTM;
    // Start is called before the first frame update
    void Start()
    {
        myTM = GetComponent<Text>();
        myTM.text = 00000.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        myTM.text = "HI: " + DinoMovement.highscore.ToString("00000");
    }
}
