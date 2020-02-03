using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    Rigidbody2D cloud;
    bool canspawn = true;
    // Start is called before the first frame update
    void Start()
    {
        cloud = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        cloud.transform.Translate(Vector2.left * SpeedFromPoints.speed * 0.1f * Time.deltaTime);
        if(PointsCalculation.points % 100 == 0 && canspawn == true)
        {
            for(int i = 0; i < 1; i++)
            {
                Instantiate(cloud, new Vector3(13, (int)Random.Range(0, 5), 0), Quaternion.identity);
                canspawn = false;
            }
        }
        PointsCalculation.points++;
        canspawn = true;
        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
}
