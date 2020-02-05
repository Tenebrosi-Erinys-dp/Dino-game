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
    // Start is called before the first frame update
    void Start()
    {
        audioJump = GetComponent<AudioSource>();
        dino = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
        dino.GetComponent<SpriteRenderer>().sprite = running;
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
        dino.GetComponent<SpriteRenderer>().sprite = running;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
        audioJump.Play(0);
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
                dino.velocity = new Vector3(0, 5.5f, 0);
                if (Input.GetAxis("Vertical") < -sensitivity)
                {
                    // TODO: implement duck animation
                    dino.velocity = new Vector3(0, -6, 0);

                }
            }
        }
        // if duck
        if (Input.GetAxis("Vertical") < -sensitivity)
        {
            dino.GetComponent<SpriteRenderer>().sprite = ducking;
            dino.velocity = new Vector3(0, -6, 0);
            if (Input.GetAxis("Vertical") > sensitivity)
            {
                // jump  velcotiy
                dino.velocity = new Vector3(0, 5.5f, 0);
            }
            // TODO: implement duck animation
            
        }
        if(Input.GetKey(""))
        {
            dino.GetComponent<SpriteRenderer>().sprite = running;
        }
    }
}
