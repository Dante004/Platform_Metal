using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
    [HideInInspector]
    public bool ground = true;
    public float speed;
    public float jump;
    [HideInInspector] public bool youAttack = false;
    Rigidbody2D rb2d;
    Animator anim;
    GameObject guitar;
    ForceMode2D force;
    bool onLadder = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        guitar = GameObject.FindGameObjectWithTag("Guitar"); //wyszukanie Triggera gitary
    }

    void Update()
    {
        ground = CheckGround();
        //Zmiana skali gracza w zależności w którą stone idzemy
        if(!youAttack)
        { 
            if(Input.GetAxis("Horizontal")>0.01)
            {
                transform.localScale = new Vector2(1,1);
            }
            if (Input.GetAxis("Horizontal") < -0.1)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            if (Input.GetAxis("Sprint") > 0)
            {
                speed = 8;
                jump = 8;
            }
            else
            {
                speed = 5;
                jump = 8;
            }
            if (!ground && Input.GetAxis("Sprint") > 0)
            {
                speed = 6;
            }
        }
        else
        {
            speed = 0;
            jump = 0;
        }
        //Wykonanie wślizgu
        if (Input.GetKey(KeyCode.G))
        {
            Slide();
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            anim.SetBool("Slide", false);
        }
    }

    void Slide()//Metoda pozwalająca na wykonanie wślizgu
    {
        if(ground==true && Mathf.Abs(Input.GetAxis("Horizontal"))>0.1) //Sprawdzenie czy gracz jest na ziemi i się porusza
        {
            anim.SetBool("Slide", true); //zmiana animacji
            rb2d.AddForce(Vector2.right * (80 * transform.localScale.x), force);
        }
    }

    void FixedUpdate()
    {
        Jump();
        float h = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector3(h * speed, rb2d.velocity.y, 0);
        anim.SetFloat("Velocity", Mathf.Abs(h));
        anim.SetBool("Ground", ground);
    }

    //Metoda pozwalająca graczowi skakać
    private void Jump()
    {
        if (Input.GetAxisRaw("Jump") > 0.1 && ground)
        {
            rb2d.velocity = new Vector3(rb2d.velocity.x, jump, 0);
        }
    }

    bool CheckGround() //Sprawdzenie czy Player dotyka gruntu
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        if(hit.collider!=null&&hit.transform.gameObject.tag=="Platform")
        {
            if(hit.distance<0.7f)
            {
                return true;
            }
            return false;
        }
        else
        {
            return false;
        }
    }


    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.tag=="Ladder")
        {
            if (onLadder)
            {
                OnLadderEnter();
            }
            else
            {
                if (Mathf.Abs(Input.GetAxisRaw("Vertical"))==1)
                {
                    onLadder = true;
                }
            }

        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Ladder")
        {
            OnLadderExit();
        }
    }

    void OnLadderEnter()
    {
        anim.SetBool("Ladder", true);
        float climbSpeed = 3;
        rb2d.gravityScale = 0;
        rb2d.velocity = new Vector2(0, 0);
        float v = Input.GetAxis("Vertical");
        anim.SetFloat("Ladder_Velocity",Mathf.Abs(v));
        transform.Translate(0, v*climbSpeed * Time.deltaTime, 0);
    }

    void OnLadderExit()
    {
        anim.SetBool("Ladder", false);
        rb2d.gravityScale = 1;
        onLadder = false;
    }
}