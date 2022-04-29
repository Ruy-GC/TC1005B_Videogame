using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float accelerationTime = 1f;
    private float time;
    private bool movementOn;
    public float speed;

    public AudioClip collisionSound;
    public Rigidbody2D rb;

    [SerializeField] private SpriteRenderer spriteRenderer;

    float side;

    //Vector3 randomDirection;
    Vector2 movement;

    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D col){
        
        if (col.gameObject.tag == "Player"){
            GetComponent<AudioSource>().PlayOneShot(collisionSound, 2.0f);
            
        }

        if (col.gameObject.tag == "wall"){
            //GetComponent<Rigidbody2D>().AddForce((movement * -1) * highSpeed);
            speed = speed * -1;
            //side = side * -1;
            //print(side);
            if (spriteRenderer.flipX){
                spriteRenderer.flipX = false;
            }else{
                spriteRenderer.flipX = true;
            }
        }
    }

    void Start(){
        movementOn = true;
        speed = 200f;
    }

    // Update is called once per frame
    void Update(){
    

        if(movementOn){
            Movement();
        }

    }


    void Movement(){
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
    }
}
