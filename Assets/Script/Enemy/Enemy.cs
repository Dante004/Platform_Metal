using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour {

    //protected float coolDownAttack = 0;
    [SerializeField] protected int life;
    [SerializeField] protected bool randomMove;
    protected GameObject player;
    protected PlayerManager pm;
    protected Animator anim;
    protected bool die = false;

    public Vector2 min, max;
    public float speed;
    public float obstackleRage = 0.5f;

    Rigidbody2D rb2d;
    bool addSouls = true;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pm = player.GetComponent<PlayerManager>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void CheckLife()
    {
        if(life == 0)
        {
            speed = 0;
            if(addSouls)
            {
                pm.AddSpirit(10);
                addSouls = false;
            }
            Death();
        }
    }

    public virtual void Attack()
    {

    }

    public void Move()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        CheckPosition();
    }

    void CheckPosition()
    {
        if (transform.localPosition.x > max.x)
        {
            speed = -speed;
            transform.localScale = new Vector3(1, 1,1);
        }
        if (transform.localPosition.x < min.x)
        {
            speed = -speed;
            transform.localScale = new Vector3(-1, 1,1);
        }
    }

    void RandomMove()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0); //Poruszanie się obiektu
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right); //Wykrywanie innych obiektów 
        if (hit.collider != null && hit.transform.gameObject.tag != "Water")
        {
            if (hit.distance < obstackleRage)
            {
                RandomRotate();
            }
        }
        if (transform.position.y > max.y)
        {
            transform.Rotate(0, 0, 180);
        }
        if (transform.position.y < min.y)
        {
            transform.Rotate(0, 0, 180);
        }
        if (transform.position.x > max.x)
        {
            transform.Rotate(0, 0, 180);
        }
        if (transform.position.x < min.x)
        {
            transform.Rotate(0, 0, 180);
        }
    }

    private void RandomRotate()
    {
        float angle = Random.Range(-100, 100);
        transform.Rotate(0, 0, angle);
    }

    public virtual void Death()
    {

    }

    void Update()
    {
        CheckLife();
        if(randomMove)
        {
            RandomMove();
        }
        else
        {
            Move();
        }
        Attack();
    }

    void Damage(int damage)
    {
        life -= damage;
        rb2d.AddForce(new Vector2(2, 7), ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Player")
        {
            coll.collider.SendMessage("ZeroSpirit");
        }
    }
}
