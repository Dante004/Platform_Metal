using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingPlatform : MonoBehaviour {

    Vector2 from;
    Vector2 to_to;
    public Vector2 to;
    public float m_frequency = 0.5F;

    void Start ()
    {
        from = new Vector2(transform.position.x, transform.position.y);
        to_to = new Vector2(transform.position.x + to.x, transform.position.y + to.y);
    }

    private void Update()
    {
        float m_lerp = 0.5F * (1.0F + Mathf.Sin(Mathf.PI * Time.realtimeSinceStartup * this.m_frequency));
        transform.position = Vector3.Lerp(from, to_to, m_lerp);
    }
}
