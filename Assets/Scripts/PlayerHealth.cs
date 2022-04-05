using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //Health
    [SerializeField]private Image healthBar;
    [SerializeField]private float currentHP;
    [SerializeField]private float maxHP = 100f;

    //enemy collision
    [SerializeField] private float force = 5;
    [SerializeField] private ForceMode2D forceMode = ForceMode2D.Impulse;
    [SerializeField] private GameObject damageUI;
    Image damageImg;


    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        damageImg = damageUI.GetComponent<Image>();
        healthBar = healthBar.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = currentHP / maxHP;

        if(currentHP <= 0){
            SceneManager.LoadScene("gameOver");
        }
    }

        //al chocar con jugador
    void OnCollisionEnter2D(Collision2D c){
        if(c.gameObject.tag == "enemy"){
            currentHP -= 10;
            //gets vomtact point and player position
            ContactPoint2D contactPoint = c.GetContact(0);
            Vector2 playerPosition = transform.position;

            //sets direction to the oppoite of the collision
            Vector2 dir = contactPoint.point - playerPosition;
            dir = -dir.normalized;
            
            //UI flash
            StartCoroutine(damageFlash());

            //Uses physics to impulse the player
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().inertia = 0;
            GetComponent<Rigidbody2D>().AddForce(dir * force, forceMode);
        }
    }

    IEnumerator damageFlash(){
            var alpha= damageImg.color;
            damageImg.color = new Color32(255,0,0,100);
            yield return new WaitForSeconds (0.1f);
            damageImg.color = new Color32(255,0,0,0);
    }
}
