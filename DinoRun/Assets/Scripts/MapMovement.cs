using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovement : MonoBehaviour
{
    Rigidbody2D mySprite;
    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mySprite.transform.Translate(Vector2.left * SpeedFromPoints.speed * Time.deltaTime);
    }
}
