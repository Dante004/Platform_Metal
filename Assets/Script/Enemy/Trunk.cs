using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trunk : Enemy {

    public GameObject leafGameobject;
    float coolDownAttack = 0;

    public override void Attack()
    {
        if(!die)
        {
            float distToPlayer = Vector2.Distance(player.transform.position, gameObject.transform.position); //wyliczanie dystansu do gracza
            Vector2 dir = (player.transform.position - transform.position).normalized;
            float direction = Vector2.Dot(dir, transform.right);
            if (distToPlayer <= 4.5f)
            {
                if (coolDownAttack <= 0)
                {
                    if (transform.localScale.x == -1 && direction > 0.9)
                    {
                        anim.SetTrigger("Attack");
                        GameObject lf = Instantiate(leafGameobject, transform.position, Quaternion.identity) as GameObject; //zespawnowanie liscia i utworzeniu z niego obiektu
                        Leaf leaf = lf.GetComponent<Leaf>(); //nadanie komponentu Leaf do liścia
                        leaf.force = 5;
                    }
                    if (transform.localScale.x == 1 && direction < -0.9)
                    {
                        anim.SetTrigger("Attack");
                        GameObject lf = Instantiate(leafGameobject, transform.position, Quaternion.identity) as GameObject;
                        Leaf leaf = lf.GetComponent<Leaf>();
                        leaf.force = -5;
                    }
                    coolDownAttack = 2;  //reset cooldownu
                }
                if (coolDownAttack > 0)
                {
                    coolDownAttack -= Time.deltaTime; //zmniejszenie cooldawnu o 1 co sekunde
                }
            }
        }
    }

    public override void Death()
    {
        die = true;
        anim.SetTrigger("Die");
        speed = 0;
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Trunk_Die"))
        {
            Destroy(gameObject,1);
        }
    }

}
