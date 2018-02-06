using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Level/LevelInformation")]
public class LevelInformation : MonoBehaviour {
    public int level;
    public Vector3 cameramax;
    public Vector3 cameramin;
    CameraMovement cm;

    void Awake()
    {
        cm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag=="Player")
        {
            cm.cameramax = this.cameramax;
            cm.cameramin = this.cameramin;
        }
    }
}
