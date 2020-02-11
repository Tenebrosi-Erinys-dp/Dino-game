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
        // set the states to running, the way they start of
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
    // animation caller for the landing
    public IEnumerator LandAnim()
    {
        // call the animation, wait and update states
        gameObject.GetComponent<Animator>().SetInteger("State", 1);
        yield return new WaitForSeconds(0.2f);
        previousState = currentState;
        currentState = State.Running;
    }
    public IEnumerator JumpAnim()
    {
        // call the animation, wait and adjust colliders, velocity and states
        gameObject.GetComponent<Animator>().SetInteger("State", 2);
        yield return new WaitForSeconds(0.2f);
        dino.velocity = new Vector3(0, 19.5f, 0);
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<Animator>().SetInteger("State", 3);
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0f);
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(5f, 4f);
        previousState = currentState;
        currentState = State.Air;
    }
    // when the dino hits something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if upon entering a collision its coming from the air
        if(currentState == State.Air)
        {
            // set the current state to landing and start the landing animation and procedure
            currentState = State.Landing;
            StartCoroutine(LandAnim());
        }
        // if upon entering a collision its an enemy sprite
        if (collision.gameObject.tag == "IsSprite")
        {
            // stop the looping music, call the death animation, and display the deathscreen
            GameObject.FindGameObjectWithTag("Music").GetComponent<LoopingMusic>().playing = false;
            hit = true;
            gameObject.GetComponent<Animator>().SetInteger("State", 4);
            canvas[0].SetActive(true);
            canvas[1].SetActive(true);
            highscoreT.SetActive(true);
            // stop time
            Time.timeScale = 0f;
            // set the highscore to have existed, and if the points are higher than the highscore, set those points as highscore
            if (PointsCalculation.points > DinoMovement.highscore)
            {
                DinoMovement.highscore = PointsCalculation.points;
            }
            // stop any other sound effects
            audioEffects[0].Stop();
            audioEffects[1].Stop();
        }
    }
    // when the dino is during a collision, which is during the ground
    private void OnCollisionStay2D(Collision2D collision)
    {
        // if during a constant collision, you are running or ducking
        if(currentState == State.Running || currentState == State.Ducking)
        {
            // if you press up, call the jumping procedure
            if(Input.GetAxis("Vertical") > sensitivity)
            {
                // call jumping procedure
                currentState = State.Jumping;
                StartCoroutine(JumpAnim());
                audioEffects[0].Play(0);
                jumped = false;
                previousState = State.Air;
            }
            // if you press down, call the ducking procedure
            if(Input.GetAxis("Vertical") < -sensitivity)
            {
                // ducking hitbox adjustment, state adjustment and velocity adjustment if needed
                dino.velocity = new Vector3(0, -10, 0);
                gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, -0.5f);
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(5f, 3f);
                currentState = State.Ducking;
            }
            // if changing state from running to ducking
            if(previousState != State.Ducking && currentState == State.Ducking)
            {
                // change animation and sound effect to ducking
                gameObject.GetComponent<Animator>().SetInteger("State", 5);
                audioEffects[1].Play(0);
            }
            // if changing state from ducking to running
            if (previousState != State.Running && currentState == State.Running)
            {
                // change animation to running
                gameObject.GetComponent<Animator>().SetInteger("State", 0);
            }
            // store the state
            previousState = currentState;
        }
    }
    // when the dino leaves a collision, during a jump
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if 100 points are reached,  close and open the white block 4 times over the score to provide the animation
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
