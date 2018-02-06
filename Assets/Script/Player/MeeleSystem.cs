using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleSystem : MonoBehaviour {

    Rigidbody2D rb2dPlayer;
    Animator anim;
    GameObject player;
    Animator animPlayer;
    Move move;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        animPlayer = player.GetComponentInParent<Animator>();
        move = player.GetComponentInParent<Move>();
        rb2dPlayer = GetComponentInParent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") &&  move.ground && !animPlayer.GetBool("Ladder"))
        {
            Attack1();
        }
        if (Input.GetButtonDown("Fire2") && move.ground && !animPlayer.GetBool("Ladder"))
        {
            Attack2();
        }
        if (Input.GetButtonDown("Fire1") && !move.ground && !animPlayer.GetBool("Ladder"))
        {
            Attack3();
        }
        if (animPlayer.GetCurrentAnimatorStateInfo(0).IsName("Player_Attack1")|| animPlayer.GetCurrentAnimatorStateInfo(0).IsName("Player_Attack2"))//sprawdzanie czy postac atakuje
        {
            move.youAttack = true;
        }
        else
        {
            move.youAttack = false;
        }

    }

    void Attack1()
    {
        anim.SetTrigger("Attack1");
        animPlayer.SetTrigger("Attack1");
    }

    void Attack2()
    {
        anim.SetTrigger("Attack2");
        animPlayer.SetTrigger("Attack2");
    }

    void Attack3()
    {
        if(!animPlayer.GetCurrentAnimatorStateInfo(0).IsName("Player_Attack_From_Air"))
        {
            animPlayer.SetBool("Attack3",true);
            rb2dPlayer.AddForce(Vector2.down * 20, ForceMode2D.Impulse);
        }
    }


    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag=="Enemy")
        {
            coll.SendMessageUpwards("Damage", 1);
        }
    }
}
