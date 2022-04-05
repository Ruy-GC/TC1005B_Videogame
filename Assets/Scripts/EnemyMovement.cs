using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float accelerationTime = 1f;
    public float lowSpeed = 10f;
    public float highSpeed = 50f;
    private float time;
    //public float speed;

    public AudioClip collisionSound;

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
            movement = movement * -1;
            side = side * -1;
            print(side);
            if (spriteRenderer.flipX){
                spriteRenderer.flipX = false;
            }else{
                spriteRenderer.flipX = true;
            }
        }
    }

    // Update is called once per frame
    void Update(){
        //timeVar += step;
        time -= Time.deltaTime;
        side = Random.Range(-5,5);
        if(time <= 0){
            movement = new Vector2(side, 0);
    
            time += accelerationTime;
            if (side > 0 ){
                spriteRenderer.flipX = true;
            }else if(side < 0){
                spriteRenderer.flipX = false;
            }
        }

        


        //GetComponent<Rigidbody2D>().AddForce(transform.forward * speed, ForceMode2D.Impulse);
    }

    void FixedUpdate(){
        GetComponent<Rigidbody2D>().AddForce(movement * highSpeed);
    }
}
