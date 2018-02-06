using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadMarker : MonoBehaviour {

    GameObject player;
    PlayerManager pm;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pm = player.GetComponent<PlayerManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        pm.ZeroSpirit();
    }

}
