using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario_Control : MonoBehaviour
{
    public Animator anim;

    // [HideInInspector]
    public bool dirRight = true;
    public bool jump = false;
    public float jumpForce = 1000f;

    public bool grounded = false;
    public bool bricks = false;
    public bool questions = false;

    private Transform GroundCheck;

    public float moveForce = 0.1f;
    public float maxSpeed = 0.2f;
    private float a;
    private float b;
    public float fire;

    private float h;
    private float F_h;

    void Awake()
    {
        GroundCheck = transform.Find("GroundCheck");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        bricks = Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Brick"));
        questions = Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Question"));

        if (grounded || bricks || questions)
        {
            anim.SetBool("Jump",false);
        }

        if(Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }

        if(Input.GetButtonDown("Jump") && bricks)
        {
            jump = true;
        }

        if(Input.GetButtonDown("Jump") && questions)
        {
            jump = true;
        }

        if (transform.position.y <= 0.3892f && grounded)
        {
            transform.position = new Vector3(transform.position.x, 0.3892f, transform.position.z);
        }

        // if (grounded)
        //     GetComponent<Rigidbody2D>().velocity = new Vector2(a, GetComponent<Rigidbody2D>().velocity.y);

    }

    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(h));

        if(h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);
        }

        if(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if(h > 0 && !dirRight)
        {
            Flip();
        }
        else if (h < 0 && dirRight)
        {
            Flip();
        }

        if (Mathf.Abs(h - F_h) >= 0.1)
        {
            anim.SetBool("Turn",true);
        }
        else
        {
            anim.SetBool("Turn",false);
        }

        F_h = h;



        if (jump)
        {
            anim.SetBool("Jump", true);

            a = GetComponent<Rigidbody2D>().velocity.x;
            b = GetComponent<Rigidbody2D>().angularVelocity;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));

            jump = false;
        }

        fire = Input.GetAxis("Fire1");
        if (GameObject.Find("Mario2"))
        {
            if (fire != 0)
            {
                anim.SetBool("Attack",true);
            }

            if (fire == 0)
            {
                anim.SetBool("Attack",false);
            }
        }
    }

    void Flip()
    {
        dirRight = !dirRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag == "Ground")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(a, GetComponent<Rigidbody2D>().velocity.y);
            GetComponent<Rigidbody2D>().angularVelocity = b;
        }

        if(GameObject.Find("Mario2") && other.tag == "Flower")
        {
            Destroy(other.transform.root.gameObject);
        }
    }
}