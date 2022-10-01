using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCC : MonoBehaviour
{
    private float moveHorizontal;
    private float moveVertical;
    private Vector2 currentVelocity;
    [SerializeField]
    private float movementSpeed = 3f;
    [SerializeField]
    private float movementSpeedVertical = 10f;
    private Rigidbody2D characterRigidBody;
    private bool isGrounded = true;

    // Start is called before the first frame update
    private void Start() 
    {
        this.characterRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        this.moveHorizontal = Input.GetAxis("Horizontal"); // X-Axis
        this.moveVertical = Input.GetAxis("Vertical"); // Y-Axis
        this.currentVelocity = this.characterRigidBody.velocity;

        if (this.moveHorizontal != 0){
            this.characterRigidBody.velocity = new Vector2(this.moveHorizontal * this.movementSpeed, this.currentVelocity.y);
        }

        if (this.moveVertical > 0 && isGrounded){ // Jump
            print("Jumped");
            this.characterRigidBody.velocity = new Vector2(this.currentVelocity.x, this.movementSpeedVertical);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collisin with: " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        print("Exit Collisin with: " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }
    
}


