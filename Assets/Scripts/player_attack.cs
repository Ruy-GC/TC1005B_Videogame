using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_attack : MonoBehaviour
{

    public Player player;
    [SerializeField] private Animator anim;

    //attack properties
    [SerializeField] private float attackTime;
    [SerializeField] private float startAttackTime;
    [SerializeField] private Transform attackLocation;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask enemies;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isLeft){
            direction = new Vector3 (-1.5f,0f,0f);
        }else{
            direction = new Vector3 (1.5f,0f,0f);
        }

        if(attackTime <= 0){
            if(Input.GetKeyDown(KeyCode.X)){
                anim.SetBool("is_attacking", true);
                attackTime = startAttackTime;
                Collider2D[] damage = Physics2D.OverlapCircleAll( attackLocation.position + direction, attackRange, enemies );
                
                StartCoroutine(destroyE(damage));
            }
        }else{
            attackTime -= Time.deltaTime;
            anim.SetBool("is_attacking", false);
        }
    }

    IEnumerator destroyE(Collider2D[] damage){
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < damage.Length; i++)
                {
                    Destroy( damage[i].gameObject );
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackLocation.position + direction, attackRange);
    }
}
