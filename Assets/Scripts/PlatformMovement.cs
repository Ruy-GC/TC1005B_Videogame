using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    float directionX, speed = 2.5f;
    bool movement = true;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 10)
            movement = false;
        if(transform.position.x < -10f)
            movement = true;

        if(movement)
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
    }
}
