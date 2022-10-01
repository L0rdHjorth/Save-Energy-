using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LysCounter : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        int antalLysSlukket = player.GetComponent<MoveController>().lysSlukket;
        int antalLysIAlt = player.GetComponent<MoveController>().lysArray.Length + player.GetComponent<MoveController>().kontaktArray.Length + player.GetComponent<MoveController>().lightsInKontakter;
        GetComponent<Text>().text = "Antal lys slukket: " + antalLysSlukket + "/" + antalLysIAlt;
    }
}
