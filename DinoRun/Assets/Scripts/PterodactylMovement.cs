using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PterodactylMovement : MonoBehaviour
{
    Rigidbody2D dino;
    public GameObject canvas;
    private void OnCollisionEnter2D(Collision2D collision)
    {
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
        dino = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
        gameObject.GetComponent<Animator>().SetInteger("State", 0);

    }

    // Update is called once per frame
    void Update()
    {
        float sensitivity = 0.00001f;
        if (dino.transform.position.y < 4)
        {
            if (Input.GetAxis("Vertical") > sensitivity)
            {
            // jump  velcotiy
            dino.velocity = new Vector3(0, 4, 0);
                gameObject.GetComponent<Animator>().SetInteger("State", 1);
            }
            // if duck
            else if (Input.GetAxis("Vertical") < -sensitivity)
            {
            dino.velocity = new Vector3(0, -4, 0);
                gameObject.GetComponent<Animator>().SetInteger("State", 2);
            } else
            {
                gameObject.GetComponent<Animator>().SetInteger("State", 0);
                dino.velocity = new Vector3(0, 0, 0);
            }
        } else
        {
            dino.velocity = new Vector3(0, 0, 0);
            dino.position = new Vector3(transform.position.x, 3.99f, transform.position.z);
        }
    }
}
