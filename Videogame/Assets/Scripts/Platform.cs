using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;

    int playerLayer, platformLayer;
    bool JumpOffIsRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerLayer = LayerMask.NameToLayer("Player");
        platformLayer = LayerMask.NameToLayer("Platform");
        float vertical = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCOllisionStay2D (Collision2D c)
    {
        print("c");
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown("joystick Y Axis -1"))
        {
            print("down");
        }
        /*float vertical = Input.GetAxis("Vertical");
        if (c.gameObject.tag == "Player" && vertical)
        {

        }*/
    }

    IEnumerator JumpOff()
    {
        JumpOffIsRunning = true;
        Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, false);
        JumpOffIsRunning = false;
    }
}
