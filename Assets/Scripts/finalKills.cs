using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalKills : MonoBehaviour
{

    [SerializeField] private player_attack player_attack;
    [SerializeField] private GameObject killsUI;

    Text killsText;

    // Start is called before the first frame update
    void Start()
    {
        killsText = killsUI.GetComponent<Text>();
        killsText.text = "Kills: " +  player_attack.kills;

    }
}
