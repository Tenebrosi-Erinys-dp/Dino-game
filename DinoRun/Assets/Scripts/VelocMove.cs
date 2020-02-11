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
    public int temppoints;
    public GameObject[] canvas;
    public GameObject highscoreT;
    public GameObject whitesquare;
    AudioSource[] audioEffects;
    public int count;
    private float sensitivity = 0.00001f;
    public static bool hit = false;
    public bool jumped = false;
    public bool landed = false;
    public bool ducking = false;
    public bool playing = false;
    public bool isPlay = false;
    public enum State { Jumping, Landing, Running, Ducking, Air };
    public State currentState;
    public State previousState;
    public string state;
    public float lasty;
    // Start is called before the first frame update
    void Start()
    {
        previousState = State.Running;
        currentState = State.Running;
        // setup the right hitbox size, the right animation, audioclip, time and rigidbody.
        gameObject.GetComponent<Animator>().SetInteger("State", 0);
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0f);
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(5f, 4f);
        audioEffects = GetComponents<AudioSource>();
        dino = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
        hit = false;

    }
    public IEnumerator LandAnim()
    {
        gameObject.GetComponent<Animator>().SetInteger("State", 1);
        yield return new WaitForSeconds(0.2f);
        previousState = currentState;
        currentState = State.Running;
    }
    public IEnumerator JumpAnim()
    {
        gameObject.GetComponent<Animator>().SetInteger("State", 2);
        yield return new WaitForSeconds(0.5f);
        dino.velocity = new Vector3(0, 19.5f, 0);
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0f);
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(5f, 4f);
        previousState = currentState;
        currentState = State.Air;
    }
    // when the dino hits something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(currentState == State.Air)
        {
            currentState = State.Landing;
        StartCoroutine(LandAnim());
            // if dino hits literally something of tag sprite, start the death sequence and store the highscore
            
        print("enter collison");
            // stop the sound effect
        }
        if (collision.gameObject.tag == "IsSprite")
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<LoopingMusic>().playing = false;
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
            audioEffects[0].Stop();
            audioEffects[1].Stop();
        }




    }
    // when the dino is during a collision, which is during the ground
    private void OnCollisionStay2D(Collision2D collision)
    {
        print("test");
        if(currentState == State.Running || currentState == State.Ducking)
        {
            if(Input.GetAxis("Vertical") > sensitivity)
            {
                currentState = State.Jumping;
            }
            if(Input.GetAxis("Vertical") < -sensitivity)
            {
                dino.velocity = new Vector3(0, -10, 0);
                gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, -0.5f);
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(5f, 3f);
                currentState = State.Ducking;
            }
            if(previousState != State.Ducking && currentState == State.Ducking)
            {
                gameObject.GetComponent<Animator>().SetInteger("State", 5);
                audioEffects[1].Play(0);
            }
            if (previousState != State.Running && currentState == State.Running)
            {
                gameObject.GetComponent<Animator>().SetInteger("State", 0);
            }
            previousState = currentState;
        }
    }
    // when the dino leaves a collision, during a jump
    private void OnCollisionExit2D(Collision2D collision)
    {
        // set the idle animation and call the jump sound
        if(currentState == State.Jumping)
        {
            StartCoroutine(JumpAnim());
            audioEffects[0].Play(0);
            jumped = false;
        previousState = State.Air;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // if 100 points are reached, repeatedly close and open the white block above the score to provide the animation
        if (PointsCalculation.points % 100 == 0 && PointsCalculation.points != 0)
        {
            StartCoroutine(Fade(whitesquare));
        }
        // if there was a previous highscore in the game, use that as a highscore
        if (DinoMovement.hadHighScore == true)
        {
            highscoreT.SetActive(true);
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
