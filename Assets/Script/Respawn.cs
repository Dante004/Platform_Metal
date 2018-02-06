using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag=="Player")
        {
            FindObjectOfType<PlayerManager>().ChangeRespawn(transform.position);
        }
    }

}
