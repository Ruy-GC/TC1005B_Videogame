using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //movement
    [SerializeField] private float velocidad;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpAmount = 7;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public bool isLeft;

    //ground check
    [SerializeField] private float distanceToCheck = 0.1f;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.name.Equals("Platform"))
            this.transform.parent = col.transform;
    }

    void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.name.Equals ("Platform"))
            this.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {   
        //horizontal movement
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal < 0 ){
            spriteRenderer.flipX = true;
            isLeft = true;
        }else if(horizontal > 0){
            spriteRenderer.flipX = false;
            isLeft = false;
        }

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
}


