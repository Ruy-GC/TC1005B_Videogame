using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GenerateEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    float num;
    public int limit;
    public Button yourButton;
    public GameObject enemy;
    public GameObject leftBorder;
    public GameObject rightBorder;
    EventSystem m_EventSystem;


    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        //get current selecter gameobject
        m_EventSystem = EventSystem.current;

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void TaskOnClick()
    {
        if(limit < 5)
        {
            //get an x position between the two borders
            num = Random.Range(leftBorder.transform.position.x , rightBorder.transform.position.x);
            //generate new enemy
            Instantiate(enemy, new Vector3(num, 2, 0),transform.rotation);
            //teke focus out of the button
            m_EventSystem.SetSelectedGameObject(enemy);
            limit = limit + 1;
        }
    }

}