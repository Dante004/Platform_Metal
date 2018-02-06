using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spirit : MonoBehaviour {

    Text text;
    PlayerManager pm;
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pm = player.GetComponent<PlayerManager>();
        text = GetComponent<Text>();
    }

    void Update ()
    {
        text.text = "Souls: " + pm.currentSpirit;
	}
}
