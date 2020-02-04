using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoMovement : MonoBehaviour
{
    Rigidbody2D dino;
    bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        dino = GetComponent<Rigidbody2D>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        // if dino hits literally something -- TODO: add fix to only with object of type sprite
        if (collision.gameObject.GetComponent<CactusDeath>() == true)
        {
            
            // check if object is sprite

            // display death screen & option to restart

            // display highscore

            // remove controls
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        float sensitivity = 0.00001f;
        // if jump
        if (canJump == true)
        {
            if (Input.GetAxis("Vertical") > sensitivity)
            {
                // jump  velcotiy
                dino.velocity = new Vector3(0, 5, 0);
            }
        }
        // if duck
        if (Input.GetAxis("Vertical") < -sensitivity)
        {
            // TODO: implement duck animation
            dino.velocity = new Vector3(0, -6, 0);
        }
    }
}
