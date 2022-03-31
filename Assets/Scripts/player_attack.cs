using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_attack : MonoBehaviour
{

    [SerializeField]
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)){
            anim.SetBool("is_attacking", true);
            StartCoroutine(hold_attack());
        }

        
    }

    IEnumerator hold_attack(){
        yield return new WaitForSeconds(1);
        anim.SetBool("is_attacking", false);
    }
}
