using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      gameObject.GetComponent<Animator>().SetInteger("State", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
