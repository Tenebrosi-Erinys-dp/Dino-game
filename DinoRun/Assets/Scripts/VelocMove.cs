using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocMove : MonoBehaviour
{
    Rigidbody2D dino;
    public bool canJump = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        dino = GetComponent<Rigidbody2D>();
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
                dino.velocity = new Vector3(0, 10, 0);
            }
        }
        if (Input.GetAxis("Vertical") < -sensitivity)
        {
            // TODO: implement duck animation
            dino.velocity = new Vector3(0, -20, 0);
        }
    }
}
