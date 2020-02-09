/* VelocMove.cs
 * By: Alex Dzius
 * Last Edited: 2/10/2020
 * Description: Code that allows for the movement, death, animations and soundeffects of the velociraptor in its level. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocMove : MonoBehaviour
{
    Rigidbody2D dino;
    bool canJump = true;
    public Sprite running;
    public Sprite ducking;
    public Sprite dead;
    public GameObject canvas;
    AudioSource audioJump;
    float sensitivity = 0.00001f;
    // Start is called before the first frame update
    void Start()
    {
        // set the animation, time, sounds and rigidbody to the right state
        gameObject.GetComponent<Animator>().SetInteger("State", 0);
        audioJump = GetComponent<AudioSource>();
        dino = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        audioJump.Stop();
        // if dino hits literally something that is an enemy sprite
        if (collision.gameObject.tag == "IsSprite")
        {
            // launch deathscreen and set highscore
            canvas.SetActive(true);
            Time.timeScale = 0f;
            if (PointsCalculation.points > DinoMovement.highscore)
            {
                DinoMovement.highscore = PointsCalculation.points;
            }

        }
    }
    // when the dino is during a collision, which is during the ground
    private void OnCollisionStay2D(Collision2D collision)
    {
        canJump = true;
        // load the ducking animation if down is pressed
        if (Input.GetAxis("Vertical") < -sensitivity)
        {
            gameObject.GetComponent<Animator>().SetInteger("State", 1);
        }
        // load the running animation if up is pressed
        else
        {
            gameObject.GetComponent<Animator>().SetInteger("State", 0);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // set the idle animation and call the jump sound
        gameObject.GetComponent<Animator>().SetInteger("State", 2);
        canJump = false;
        audioJump.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        // if jumping is possible
        if (canJump == true)
        {
            // if up is pressed
            if (Input.GetAxis("Vertical") > sensitivity)
            {
                // start jumping
                dino.velocity = new Vector3(0, 150f, 0);
                if (Input.GetAxis("Vertical") < -sensitivity)
                {
                    // if pressed down again, move down
                    dino.velocity = new Vector3(0, -30, 0);

                }
            }
        }
        // if down is pressed
        if (Input.GetAxis("Vertical") < -sensitivity)
        {
            // start ducking
            dino.velocity = new Vector3(0, -30, 0);
            if (Input.GetAxis("Vertical") > sensitivity)
            {
                // if up is pressed again, move up
                dino.velocity = new Vector3(0, 150f, 0);
            }

        }
    }
}
