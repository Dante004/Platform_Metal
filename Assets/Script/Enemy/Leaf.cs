using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour {

    public float force=5;

    void Update ()
    {
        transform.position += new Vector3(force * Time.deltaTime, 0, 0);
        Destroy(gameObject,5);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag=="Player")
        {
            coll.SendMessageUpwards("ZeroSpirit");
            Destroy(gameObject);
        }
    
    }
}
