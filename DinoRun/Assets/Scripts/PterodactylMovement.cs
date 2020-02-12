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
    public GameObject[] canvas;
    public Animation anim;
    public AudioSource[] pterosound;
    public GameObject highscoreT;
    public bool ready = true;
    public static bool hit2 = false;
    public enum States { Alive, NotAlive };
    public States currentStates;

    // iEnumerator to set the animation as intended as death is detected.
    public IEnumerator Death()
    {
        // adjust animations scale and call it
        gameObject.transform.localScale = new Vector3(.5f, .5f, .5f);
        gameObject.GetComponent<Animator>().SetInteger("State", 3);
        // wait till animation is over
        yield return new WaitForSeconds(1f);
        // stop all time
        Time.timeScale = 0f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if the current state is being alive
        if (currentStates == States.Alive)
        {
            // and if the collided object is an enemy sprite
            if (collision.gameObject.tag == "IsSprite")
            {
                // set being dead to true and stop the background music
                hit2 = true;
                GameObject.FindGameObjectWithTag("Music").GetComponent<LoopingMusic>().playing = false;
                currentStates = States.NotAlive;
                StartCoroutine(Death());
                print("after anim 2");
                // play death sound
                pterosound[0].Play();
                // open the deathscreen
                canvas[0].SetActive(true);
                print("canvas1");
                canvas[1].SetActive(true);
                print("canvas2");
                // set the highscore existing to true, and assign the highscore to it if it is a highscore
                DinoMovement.hadHighScore = true;
                if (PointsCalculation.points > DinoMovement.highscore)
                {
                                DinoMovement.highscore = PointsCalculation.points;
                }
            }
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        // set being alive or not dead to be true
        currentStates = States.Alive;
        hit2 = false;
        // set the animation, time and rigidbody to the right state, and set time to be usual
        dino = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
        gameObject.GetComponent<Animator>().SetInteger("State", 0);
        anim = gameObject.GetComponent<Animation>();
        pterosound = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // if the object is not hit == currently alive
        if (hit2 == false)
        {
            float sensitivity = 0.00001f;
            // if there was a previous highscore in the game, use that as a highscore
            if (DinoMovement.hadHighScore == true)
            {
                highscoreT.SetActive(true);
            }
            // if the dino is below the maximum height of the gamescreme
            if (dino.transform.position.y < 4)
            {
                // if up is pressed
                if (Input.GetAxis("Vertical") > sensitivity)
                {
                    // fly up and call fly up animation
                    pterosound[1].Play();
                    dino.velocity = new Vector3(0, 4, 0);
                gameObject.GetComponent<Animator>().SetInteger("State", 1);
            }
            // if down is pressed
            else if (Input.GetAxis("Vertical") < -sensitivity)
            {
                // fly down and call fly down animation
                dino.velocity = new Vector3(0, -4, 0);
                gameObject.GetComponent<Animator>().SetInteger("State", 2);
            }
            else
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
    
}
