using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOffPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    private PlatformEffector2D effector;
    public float waitTime;
    
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //Checks if the down arrow has been released
        if(Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp("joystick button 1"))
        {
            waitTime = 0.1f;
        }

        //The player will be able to jump off the platform if they press the down arrow for a minimum of .1s
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) || Input.GetKey("joystick button 1"))
        {
            if(waitTime <=0){
                effector.rotationalOffset = 180f;
                waitTime = 0.1f;
            } else{
                waitTime -= Time.deltaTime;
            }
        }

        //Return the offset to 0 so the player can jump through the platform and stand over it.
        if(Input.GetKey(KeyCode.Space) || Input.GetKey("joystick button 0"))
        {
            effector.rotationalOffset = 0;
        }
    }
}
