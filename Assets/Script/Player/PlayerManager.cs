using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    Rigidbody2D rb2d;
    Animator anim;
    Move move;
    Vector3 respawnPoint;
    bool live = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        move = GetComponent<Move>();
    }

    void Update()
    {
        CheckLife();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag=="Guitar_Pick")
        {
            Destroy(coll.transform.gameObject);
        }
    }

    public int currentSpirit = 0;

    public void AddSpirit(int valume)
    {
        currentSpirit += valume;
    }

    public void ZeroSpirit()
    {
        if(currentSpirit>0)
        {
            currentSpirit = 0;
            rb2d.AddForce(new Vector2(8, 2), ForceMode2D.Impulse);
        }
        else
        {
            anim.SetTrigger("Die");
            live = false;
        }
    }

    public void ChangeRespawn(Vector3 xy)
    {
        respawnPoint = new Vector3(xy.x, xy.y, 0);
    }

    void CheckLife()
    {
        if(!live)
        {

            move.enabled = false;
            StartCoroutine("Respawn");
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(0.5f);
        transform.position = new Vector2(respawnPoint.x, respawnPoint.y);
        yield return new WaitForSeconds(0.5f);
        move.enabled = true;
        live = true;
    }
}
