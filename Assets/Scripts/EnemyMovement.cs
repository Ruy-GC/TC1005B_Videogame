using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    public float lowSpeed;
    public float highSpeed;
    float speed;

    public string [] collisions;
    public AudioClip collisionSound;

    float step = Mathf.PI / 60;
    float timeVar = 0;
    float rotationRange = 120;
    float baseDirection = 0;

    Vector3 randomDirection;

    // Start is called before the first frame update
    void CollisionStart(Collision col){
        if (col.gameObject.tag == collisions[0]){
            GetComponent<AudioSource>().PlayOneShot(collisionSound, 2.0f);
            baseDirection = baseDirection + Random.Range(-30, 30);
        }
    }

    // Update is called once per frame
    void Update(){
        randomDirection = new Vector3(0, Mathf.Sin(timeVar) * (rotationRange / 2) + baseDirection, 0);
        timeVar += step;
        speed = Random.Range(lowSpeed, highSpeed);
        GetComponent<Rigidbody2D>().AddForce(transform.forward * speed);
        transform.Rotate(randomDirection * Time.deltaTime * 10.0f);
    }
}
