/* PterodactylMovement.cs
 * By: Alex Dzius
 * Last Edited: 2/10/2020
 * Description: Code that allows for the movement, animations and death of the player-controlled Pterodactyl . 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PterodactylMovement : MonoBehaviour
{
    Rigidbody2D dino;
    public GameObject canvas;
    // when the pterodactyl hits an enemy object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if object is a sprite, call the deathscreen and kill it
        if (collision.gameObject.tag == "IsSprite")
        {
            canvas.SetActive(true);
            Time.timeScale = 0f;
            if (PointsCalculation.points > DinoMovement.highscore)
            {
                DinoMovement.highscore = PointsCalculation.points;
            }

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // set the animation, time and rigidbody to the right state
        dino = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
        gameObject.GetComponent<Animator>().SetInteger("State", 0);

    }

    // Update is called once per frame
    void Update()
    {
        float sensitivity = 0.00001f;
        // if the dino is below the maximum height of the gamescreme
        if (dino.transform.position.y < 4)
        {
            // if up is pressed
            if (Input.GetAxis("Vertical") > sensitivity)
            {
                // fly up and call fly up animation
                dino.velocity = new Vector3(0, 4, 0);
                gameObject.GetComponent<Animator>().SetInteger("State", 1);
            }
            // if down is pressed
            else if (Input.GetAxis("Vertical") < -sensitivity)
            {
                // fly down and call fly down animation
                dino.velocity = new Vector3(0, -4, 0);
                gameObject.GetComponent<Animator>().SetInteger("State", 2);
            } else
            {
                // keep the idle animation and keep constant motion 
                gameObject.GetComponent<Animator>().SetInteger("State", 0);
                dino.velocity = new Vector3(0, 0, 0);
            }
        }
        // if the dino reaches the roof
        else
        {
            // delete the velocity and move the dino down
            dino.velocity = new Vector3(0, 0, 0);
            dino.position = new Vector3(transform.position.x, 3.99f, transform.position.z);
        }
    }
}
