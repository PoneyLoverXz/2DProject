using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    private Rigidbody2D rb;
    private CollisionDetection coll;
    [SerializeField]
    private Animator animator;

    public float speed;
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private bool doubleJump;

    // Use this for initialization
    void Awake () {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CollisionDetection>();
        doubleJump = true;
    }

    // Update is called once per frame
    void Update () {
        UpdatePosition();
        Move();
        Fall();
    }

    private void UpdatePosition()
    {
        if (coll.onGround)
        {
            doubleJump = true;
        }
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        Walk(new Vector2(x, y));

        if (x != 0)
        {
            animator.SetBool("IsWalking", true);

            if (x < 0)
            {
                gameObject.transform.localScale = new Vector3(-1,1,1);
            }
            else
            {
                gameObject.transform.localScale = Vector3.one;
            }
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        var jump = Input.GetButtonDown("Jump");
        if (jump)
        {
            if (coll.onGround)
            {
                Jump(Vector2.up);
            }
            else if (doubleJump)
            {
                Jump(Vector2.up, true);
            }
        }
    }
    
    private void Walk(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
    }

    private void Jump(Vector2 dir, bool isDoubleJump = false)
    {
        Vector2 jumpVelocity;
        if(!isDoubleJump)
        {
            jumpVelocity = dir * jumpForce;
        }
        else
        {
            jumpVelocity = dir * jumpForce * 0.8f;
            doubleJump = false;
        }

        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpVelocity;
    }

    private void Fall()
    {
       if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
