using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //movement
    public float velocidad;
    public Rigidbody2D rb;
    public float jumpAmount = 7;

    //enemy collision
    public float force = 5;
    public ForceMode2D forceMode = ForceMode2D.Impulse;

    //ground check
    public float distanceToCheck = 0.1f;
    bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal movement
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(
            velocidad * horizontal * Time.deltaTime,
            0,
            0,
            Space.World
            );

         
        //checks if character is grounded using raycast
        //we set the origin of the raycast at the bottom of the character
        if (Physics2D.Raycast(transform.position + new Vector3(0f,-1f,0f), Vector3.down, distanceToCheck))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        //jumping
        //on pressing space or joystick button 0 (A(xbox), X(ps), B (switch)
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
        {

            if (isGrounded){
                //adds an impulse in the up direction of a 2D vector
                rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            }

        }
    }

    //al chocar con jugador
    void OnCollisionEnter2D(Collision2D c){
        if(c.gameObject.tag == "enemy"){
            print("pp");
            ContactPoint2D contactPoint = c.GetContact(0);
            Vector2 playerPosition = transform.position;
            Vector2 dir = contactPoint.point - playerPosition;
            dir = -dir.normalized;

            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().inertia = 0;
            GetComponent<Rigidbody2D>().AddForce(dir * force, forceMode);
        }
    }
}
