using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_attack : MonoBehaviour
{

    [SerializeField] private Player player;
    [SerializeField] private Animator anim;

    //attack properties
    [SerializeField] private float attackTime;
    [SerializeField] private float startAttackTime;
    [SerializeField] private Transform attackLocation;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask enemies;
    [SerializeField] private GameObject killsUI;

    Vector3 direction;
    public static int kills;
    Text killsText;

    void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {   
        kills = 0;
        killsText = killsUI.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {

        killsText.text = "Kills:  " + kills;

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
                    kills++;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackLocation.position + direction, attackRange);
    }
}
