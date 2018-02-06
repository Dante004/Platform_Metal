using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimming : MonoBehaviour {

    public float swimPower;
    public float speed;

    Move move;
    ForceMode2D force;
    Rigidbody2D rb2d;
    Animator anim;

    void Start()
    {
        move = GetComponent<Move>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0.01)
        {
            transform.localScale = new Vector2(1, 1);
        }
        if (Input.GetAxis("Horizontal") < -0.1)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag=="Water")
        {
            move.enabled = false;
            anim.SetBool("Swim", true);
            anim.SetBool("Ground", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="Water")
        {
            move.enabled = true;
            anim.SetBool("Swim", false);
            anim.SetBool("Ground", false);
        }
    }

    void FixedUpdate()
    {
        if(move.enabled==false)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxis("Vertical");
            rb2d.velocity = new Vector3(h * speed, rb2d.velocity.y, 0);
            if(v<-0.1)
            {
                rb2d.velocity = new Vector3(rb2d.velocity.x, v * swimPower, 0);
            }
            if (Input.GetAxis("Jump") > 0.1)
            {
                rb2d.velocity = new Vector3(rb2d.velocity.x, swimPower, 0);
            }
            anim.SetFloat("Swim_Velocity", Mathf.Abs(h));
        }
    }

}
