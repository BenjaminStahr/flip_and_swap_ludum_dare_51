using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class Controller : MonoBehaviour
{
    // Properties
    [SerializeField]
    private float movementSpeed = 2f;
    [SerializeField]
    private float runSpeed = 4f;
    [SerializeField]
    private float jumpSpeed = 10f;
    [SerializeField]
    private float jumpSpeedLow = 4f;
    [SerializeField]
    private LayerMask groundLayer;

    private bool gunCollected = false;

    float deathtimer;

    float jumptimer;

    public bool faceLeft = true;

    // Internal
    private bool isGrounded = true;

    // Components
    private Rigidbody2D body;
    private Animator anim;
    private SpriteRenderer sr;

    bool alive = true;

    private void Start() 
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!alive)
        {
            if (Time.realtimeSinceStartup > deathtimer + 3f)
            {
                LevelStart();
            }
            return;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        GroundCheck();
        Move(moveHorizontal);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }

    public void GunCollect()
    {
        anim.SetBool("gun", true);
        anim.SetTrigger("findgun");
        gunCollected = true;
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void Move(float moveHorizontal)
    {
        bool run = Input.GetKey(KeyCode.LeftShift);
        float speed = run ? runSpeed : movementSpeed;
        body.velocity = new Vector2(moveHorizontal * speed, body.velocity.y);
        if (moveHorizontal > 0)
        {
            sr.flipX = false;
            if (faceLeft == false) 
            {
                faceLeft = true;
                Transform t = gameObject.transform.GetChild(0);
                t.Rotate(0, 180, 0);
                t.position = new Vector3(
                    t.position.x + 1.5f, 
                    t.position.y,
                    t.position.z
                    );
            }
        }
        if (moveHorizontal < 0)
        {
            sr.flipX = true;
            if (faceLeft == true)  
            {
                faceLeft = false;
                Transform t = gameObject.transform.GetChild(0);
                t.Rotate(0, 180, 0);
                t.position = new Vector3(
                    t.position.x - 1.5f,
                    t.position.y,
                    t.position.z
                    );
            }
        }
        anim.SetBool("grounded", isGrounded && body.velocity.y <= 0);
        anim.SetBool("running", run);
        anim.SetBool("walking", moveHorizontal != 0);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpSpeedLow);
            anim.SetTrigger("jump");
            jumptimer = Time.realtimeSinceStartup;
        }

        float p = Time.realtimeSinceStartup - jumptimer;
        if (p > 0.10f && p <= 0.5f)
        {
            jumptimer -= 1f;
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        }
    }

    public void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position, 
            -transform.up, 
            1.25f, 
            groundLayer.value
            );

        if (hit.collider != null && hit.collider.gameObject != gameObject)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    public void Death()
    {
        if (!alive)
        {
            return;
        }

        body.bodyType = RigidbodyType2D.Static;
        deathtimer = Time.realtimeSinceStartup;
        alive = false;
        anim.SetTrigger("death");
    }

    public void LevelStart()
    {
        alive = true;
        anim.SetTrigger("jump");
        transform.localPosition = Vector2.zero + Vector2.up * 3f;
        body.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Death();
        }
    }
}