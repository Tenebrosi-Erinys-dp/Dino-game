using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoMovement : MonoBehaviour
{
    Rigidbody2D dino;
    bool canJump = true;
    public static int highscore;
    public Sprite running;
    public Sprite ducking;
    public Sprite dead;
    public GameObject canvas;
    AudioSource audioJump;
    float sensitivity = 0.00001f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().SetInteger("State", 0);
        audioJump = GetComponent<AudioSource>();
        dino = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        audioJump.Stop();
        // if dino hits literally something -- TODO: add fix to only with object of type sprite

        if (collision.gameObject.tag == "IsSprite")
        {
            canvas.SetActive(true);
            Time.timeScale = 0f;
            if(PointsCalculation.points > highscore)
            {
                highscore = PointsCalculation.points;
            }
            dino.GetComponent<SpriteRenderer>().sprite = dead;

        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        canJump = true;
        if (Input.GetAxis("Vertical") < -sensitivity)
        {
            gameObject.GetComponent<Animator>().SetInteger("State", 1);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetInteger("State", 0);
        }

        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        dino.GetComponent<SpriteRenderer>().sprite = running;
        canJump = false;
        audioJump.Play(0);
        if (Input.GetAxis("Vertical") < -sensitivity)
        {
            dino.GetComponent<SpriteRenderer>().sprite = ducking;
        }
    }

    // Update is called once per frame
    void Update()
    {

        // if jump
        if (canJump == true)
        {
            if (Input.GetAxis("Vertical") > sensitivity)
            {
                // jump  velcotiy
                dino.velocity = new Vector3(0, 6.5f, 0);
                if (Input.GetAxis("Vertical") < -sensitivity)
                {
                    // TODO: implement duck animation
                    dino.velocity = new Vector3(0, -8, 0);

                }
            }
        }
        // if duck
        if (Input.GetAxis("Vertical") < -sensitivity)
        {
            dino.GetComponent<SpriteRenderer>().sprite = ducking;
            dino.velocity = new Vector3(0, -8, 0);
            if (Input.GetAxis("Vertical") > sensitivity)
            {
                // jump  velcotiy
                dino.velocity = new Vector3(0, 6.5f, 0);
            }
            
        }
    }
}
