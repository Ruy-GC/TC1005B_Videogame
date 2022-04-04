using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_attack : MonoBehaviour
{

    [SerializeField]
    private Animator anim;

    //attack properties
    public float attackTime;
    public float startAttackTime;
    public Transform attackLocation;
    public float attackRange;
    public LayerMask enemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(attackTime <= 0){
            if(Input.GetKeyDown(KeyCode.X)){
                anim.SetBool("is_attacking", true);
                attackTime = startAttackTime;
                Collider2D[] damage = Physics2D.OverlapCircleAll( attackLocation.position, attackRange, enemies );
                
                StartCoroutine(destroyE(damage));
            }
        }else{
            attackTime -= Time.deltaTime;
            anim.SetBool("is_attacking", false);
        }
    }

    IEnumerator destroyE(Collider2D[] damage){
        yield return new WaitForSeconds(0.4f);
        for (int i = 0; i < damage.Length; i++)
                {
                    Destroy( damage[i].gameObject );
        }
    }
}
