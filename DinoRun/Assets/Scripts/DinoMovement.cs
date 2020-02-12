/* DinoMovement.cs
 * By: Alex Dzius
 * Last Edited: 2/10/2020
 * Description: Code that allows for movement, change in hitbox, animation and sound effects throughout the game. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoMovement : MonoBehaviour
{
    Rigidbody2D dino;
    bool canJump = true;
    public bool flashing = false;
    public static int highscore;
    public int temppoints;
    public Sprite running;
    public Sprite ducking;
    public Sprite dead;
    public GameObject[] canvas;
    public GameObject highscoreT;
    public static bool hadHighScore = false;
    public GameObject whitesquare;
    AudioSource[] audioJump;
    public int count;
    private float sensitivity = 0.00001f;
    // Start is called before the first frame update
    void Start()
    {
        // setup the right hitbox size, the right animation, audioclip, time and rigidbody.
        gameObject.GetComponent<Animator>().SetInteger("State", 0);
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0f);
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.8f, 0.8f);
        audioJump = GetComponents<AudioSource>();
        dino = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
        

    }
    // when the dino hits something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // allow for the ability to jump
        canJump = true;
        // stop the sound effect
        audioJump[0].Stop();
        // if dino hits literally something of tag sprite, start the death sequence and store the highscore
        if (collision.gameObject.tag == "IsSprite")
        {
            // play death sound
            audioJump[1].Play(0);
            // open death screen and register a highscore to have existed
            hadHighScore = true;
            highscoreT.SetActive(true);
            canvas[0].SetActive(true);
            canvas[1].SetActive(true);
            gameObject.transform.localScale = new Vector3(2f,2f,2f);
            gameObject.GetComponent<Animator>().SetInteger("State", 4);
            // stop time
            Time.timeScale = 0f;
            // set new nighscore
            if (PointsCalculation.points > highscore)
            {
                highscore = PointsCalculation.points;
            }
            // call death sprite
            dino.GetComponent<SpriteRenderer>().sprite = dead;

        }
    }
    // when the dino is during a collision, which is during the ground
    private void OnCollisionStay2D(Collision2D collision)
    {
        canJump = true;
        // load the ducking animation and hitbox if down is pressed
        if (Input.GetAxis("Vertical") < -sensitivity)
        {
            gameObject.GetComponent<Animator>().SetInteger("State", 1);
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, -0.2f);
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.8f, 0.3f);
        }
        // load the running animation and hitbox elsewhere
        else
        {
            gameObject.GetComponent<Animator>().SetInteger("State", 0);
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0f);
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.8f, 0.8f);
        }
    }
    // when the dino leaves a collision, during a jump
    private void OnCollisionExit2D(Collision2D collision)
    {
        // set the idle animation and call the jump sound
        gameObject.GetComponent<Animator>().SetInteger("State", 2);
        canJump = false;
        if (Input.GetAxis("Vertical") > sensitivity)
        {
            audioJump[0].Play(0);
        }
        // if during the exit down is pressed, change the sprite to ducking sprite
        if (Input.GetAxis("Vertical") < -sensitivity)
        {
            gameObject.GetComponent<Animator>().SetInteger("State", 3);

        }
    }

    // Update is called once per frame
    void Update()
    {
        // if there was a previous highscore in the game, use that as a highscore
        if (hadHighScore == true)
        {
            highscoreT.SetActive(true);
        }
        // at any given point where down is pressed, change the aimation to ducking
        if (Input.GetAxis("Vertical") < -sensitivity)
        {
            gameObject.GetComponent<Animator>().SetInteger("State", 3);
        }
        // if jumping is allowed 
        if (canJump == true)
        {
            if (Input.GetAxis("Vertical") > sensitivity)
            {
                // set the proper jump velocity and right hitbox
                dino.velocity = new Vector3(0, 15.5f, 0);
                gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0f);
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.8f, 0.8f);
                if (Input.GetAxis("Vertical") < -sensitivity)
                {
                    // set the fall velocity and right hitbox
                    dino.velocity = new Vector3(0, -10, 0);
                    gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, -0.2f);
                    gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.8f, 0.3f);

                }
            }
        }
        // if ducking
        if (Input.GetAxis("Vertical") < -sensitivity)
        {
            // set the fall velocity and right hitbox
            dino.velocity = new Vector3(0, -10, 0);
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, -0.2f);
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.8f, 0.3f);
            gameObject.GetComponent<Animator>().SetInteger("State", 1);
            if (Input.GetAxis("Vertical") > sensitivity)
            {
                // set the proper jump velocity and right hitbox
                dino.velocity = new Vector3(0, 15.5f, 0);
                gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0f);
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.8f, 0.8f);
            }

        }
        // if 100 points are reached,  close and open the white block 4 times over the score to provide the animation for reaching a milestone
        if (PointsCalculation.points % 100 == 0 && PointsCalculation.points != 0)
        {
            StartCoroutine(Fade(whitesquare));
        }
    }

    public IEnumerator Fade(GameObject obj)
    {
        for (int i = 0; i < 4; i++)
        {
            obj.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            whitesquare.SetActive(false);
            yield return new WaitForSeconds(0.2f);
        }
    }
}