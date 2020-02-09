/* FireballMovement.cs
 * By: Alex Dzius
 * Last Edited: 2/10/2020
 * Description: Code that allows for the specfic fireball movement, which is different to the rest of the moving objects. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour
{
    // use the speed and fireball and get both as needed
    public float speed = 10.0f;
    Rigidbody2D Fireball;
    // Start is called before the first frame update
    void Start()
    {
        Fireball = GetComponent<Rigidbody2D>();
        gameObject.GetComponent<Animator>().SetInteger("State", 0);
    }

    // Update is called once per frame
    void Update()
    {
        // calculate the speed at any given frame
        speed = 10 + PointsCalculation.points / 5000f;
        // give the fireball the below speed which increases steadily over time
        Fireball.transform.Translate(new Vector2(-0.8f*1.2f, -0.2f*1.6f) * speed * 1.25f * Time.deltaTime);
    }
}
