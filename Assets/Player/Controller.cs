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
    private LayerMask groundLayer;

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
            return;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        GroundCheck();
        Move(moveHorizontal);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
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
                gameObject.transform.GetChild(0).transform.Rotate(0, 180, 0);
                gameObject.transform.GetChild(0).transform.position = new Vector3(gameObject.transform.GetChild(0).transform.position.x + 1.5f, 
                    gameObject.transform.GetChild(0).transform.position.y,
                    gameObject.transform.GetChild(0).transform.position.z);
            }

        }
        if (moveHorizontal < 0)
        {
            sr.flipX = true;
            if (faceLeft == true)  
            {
                faceLeft = false;
                gameObject.transform.GetChild(0).transform.Rotate(0, 180, 0);
                gameObject.transform.GetChild(0).transform.position = new Vector3(gameObject.transform.GetChild(0).transform.position.x - 1.5f,
                    gameObject.transform.GetChild(0).transform.position.y,
                    gameObject.transform.GetChild(0).transform.position.z);
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
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
            anim.SetTrigger("jump");
        }
    }

    public void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up , 1.25f, groundLayer.value);
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
        alive = false;
        anim.SetTrigger("death");
    }
}


