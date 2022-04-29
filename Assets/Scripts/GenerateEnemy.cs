using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GenerateEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    float num;
    //public Button yourButton;
    public GameObject enemy;
    public GameObject leftBorder;
    public GameObject rightBorder;
    EventSystem m_EventSystem;

    void Start(){
        m_EventSystem = EventSystem.current;
        StartCoroutine(addEnemy());
    }

    // Update is called once per frame
    void Update(){
    }

    IEnumerator addEnemy(){
        while(true){
            yield return new WaitForSeconds(3);
            //get an x position between the two borders
            num = Random.Range(leftBorder.transform.position.x , rightBorder.transform.position.x);
            //generate new enemy
            Instantiate(enemy, new Vector3(num, -3.5f, 0),transform.rotation);
        }
    }
}