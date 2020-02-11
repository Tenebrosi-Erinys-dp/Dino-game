﻿/* VelocMove.cs
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
    private bool hasFaded = false;
    public int temppoints;
    public GameObject[] canvas;
    public GameObject highscoreT;
    public GameObject whitesquare;
    public int count;
    private float sensitivity = 0.00001f;
    public static bool hit = false;
    public bool jumped = false;
    public bool landed = false;
    public AudioClip dinoDeathSound;
    public AudioClip dinoJumpSound;
    private AudioSource dinoJumpSource;
    public bool invincible = false;
    // Start is called before the first frame update
    void Start()
    {
        dinoJumpSource = gameObject.AddComponent<AudioSource>();
        dinoJumpSource.clip = dinoJumpSound;
        // setup the right hitbox size, the right animation, audioclip, time and rigidbody.
        gameObject.GetComponent<Animator>().SetInteger("State", 0);
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0f);
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(5f, 4f);
        dino = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
        hit = false;

    }
    public IEnumerator Landing()
    {
        gameObject.GetComponent<Animator>().SetInteger("State", 1);
        yield return new WaitForSeconds(5f);
        landed = true;
    }
    public IEnumerator Jumping()
    {
        gameObject.GetComponent<Animator>().SetInteger("State", 2);
        yield return new WaitForSeconds(2f);
        jumped = true;
    }
    // when the dino hits something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Landing());
        if (collision.gameObject.tag == "IsSprite" && !invincible)
        {
            AudioSource newAs = gameObject.AddComponent<AudioSource>();
            newAs.clip = dinoDeathSound;
            newAs.Play();
            landed = false;
            hit = true;
            gameObject.GetComponent<Animator>().SetInteger("State", 4);
            canvas[0].SetActive(true);
            canvas[1].SetActive(true);
            highscoreT.SetActive(true);
            Time.timeScale = 0f;
            if (PointsCalculation.points > DinoMovement.highscore)
            {
                DinoMovement.highscore = PointsCalculation.points;
            }
            Destroy(newAs, newAs.clip.length);
        }
        if (!canJump)
        {
            GetComponent<SFXRandomContainer>().Play();
        }
        print("enter collison");
        canJump = true;
        // stop the sound effect
        // if dino hits literally something of tag sprite, start the death sequence and store the highscore
        landed = false;
    }
    // when the dino is during a collision, which is during the ground
    private void OnCollisionStay2D(Collision2D collision)
    {
        canJump = true;
        // load the ducking animation and hitbox if down is pressed
        if (Input.GetAxis("Vertical") < -sensitivity)
        {
            gameObject.GetComponent<Animator>().SetInteger("State", 5);
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, -0.5f);
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(5f, 3f);
            GetComponent<LoopingMusic>().Begin();
        }
        // load the running animation and hitbox elsewhere
        else
        {
            gameObject.GetComponent<Animator>().SetInteger("State", 0);
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0f);
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(5f, 4f);
            GetComponent<LoopingMusic>().Stop();
        }
    }
    // when the dino leaves a collision, during a jump
    private void OnCollisionExit2D(Collision2D collision)
    {
        // set the idle animation and call the jump sound
        StartCoroutine(Jumping());
        canJump = false;
        if (jumped)
        {
            if (Input.GetAxis("Vertical") > sensitivity)
            {
                gameObject.GetComponent<Animator>().SetInteger("State", 3);
                jumped = false;
            }
            // if during the exit down is pressed, change the sprite to ducking sprite
            if (Input.GetAxis("Vertical") < -sensitivity)
            {
                gameObject.GetComponent<Animator>().SetInteger("State", 3);
                jumped = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if there was a previous highscore in the game, use that as a highscore
        if (DinoMovement.hadHighScore == true)
        {
            highscoreT.SetActive(true);
        }
        // at any given point where down is pressed, change the aimation to ducking
        if (Input.GetAxis("Vertical") < -sensitivity)
        {
            gameObject.GetComponent<Animator>().SetInteger("State", 5);
        }
        // if jumping 
        if (canJump)
        {
            if (Input.GetAxis("Vertical") > sensitivity)
            {
                print(Input.GetAxis("Vertical"));
                // set the proper jump velocity and right hitbox
                dino.velocity = new Vector3(0, 19.5f, 0);
                gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0f);
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(5f, 4f);
                dinoJumpSource.Play();
            }
            if (Input.GetAxis("Vertical") < -sensitivity)
            {
                // set the fall velocity and right hitbox
                dino.velocity = new Vector3(0, -10, 0);
                gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, -0.5f);
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(5f, 3f);
            }
        }
        // if ducking
        if (Input.GetAxis("Vertical") < -sensitivity)
        {
            // set the fall velocity and right hitbox
            dino.velocity = new Vector3(0, -10, 0);
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, -0.5f);
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(5f, 3f);
            gameObject.GetComponent<Animator>().SetInteger("State", 5);
            if (Input.GetAxis("Vertical") > sensitivity)
            {
                // set the proper jump velocity and right hitbox
                dino.velocity = new Vector3(0, 19.5f, 0);
                gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0f);
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(5f, 4f);
            }

        }
        // if 100 points are reached, repeatedly close and open the white block above the score to provide the animation
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
