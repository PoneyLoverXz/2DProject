using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("General")]
    public Camera cam;
    public Animator animator;

    [Header("Health")]
    public int currentHealth = 10;
    public int maxHealth = 10;
    public bool canTakeDamage = true;
    public float avoidSeconds;

    private bool dead = false;

    [Header("Movement")]
    public float speed;
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float minimumYVelocity = -15f;

    private GameManager gameManager;
    private HUDManager hudManager;
    private Rigidbody2D rb;
    private CollisionDetection coll;
    private CameraFollow cameraFollow;

    private bool doubleJump;

    //FOR DEBUGGING PURPOSES
    public Vector2 velo;


    void Start()
    {
        gameManager = GameManager.instance;
        hudManager = HUDManager.instance;
        hudManager.UpdateHealth(maxHealth);
        currentHealth = maxHealth;
        rb.gravityScale = 1;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CollisionDetection>();
        cameraFollow = cam.gameObject.GetComponent<CameraFollow>();
        doubleJump = true;
    }

    void Update()
    {
        Movement();
        UpdateHealth();
        velo = rb.velocity;
    }

    private void LateUpdate()
    {
        AdjustCharacterPosition();
    }

    private void AdjustCharacterPosition()
    {
        var viewPos = cam.WorldToViewportPoint(transform.position);
        if(viewPos.y < 0)
        {
            LoseHealth(currentHealth);
        }
        if (viewPos.x > 1)
        {
            transform.position = cam.ViewportToWorldPoint(new Vector3(1, viewPos.y, viewPos.z));
        }
        else if (viewPos.x < 0)
        {
            transform.position = cam.ViewportToWorldPoint(new Vector3(0, viewPos.y, viewPos.z));
        }
    }

    private void Movement()
    {
        CheckIfDoubleJump();
        Move();
    }

    private void CheckIfDoubleJump()
    {
        if (coll.onGround)
        {
            doubleJump = true;
        }
    }

    private void Move()
    {
        if(!dead)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            Walk(new Vector2(x, y));

            if (x != 0)
            {
                animator.SetBool("IsWalking", true);

                // Flip Character Sprite
                if (x < 0)
                {
                    gameObject.transform.localScale = new Vector3(-1, 1, 1);
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
    }

    private void Walk(Vector2 dir)
    {

        if (coll.onLeftWall && dir.x < 0 ||
           coll.onRightWall && dir.x > 0)
            rb.velocity = new Vector2(0, rb.velocity.y);
        else
            rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);

        Fall(dir.y);
    }

    private void Jump(Vector2 dir, bool isDoubleJump = false)
    {
        Vector2 jumpVelocity;
        if (!isDoubleJump)
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

    private void Fall(float y)
    {
        if (y < 0 && !coll.onGround && rb.velocity.y <= 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, minimumYVelocity);
        }
        if (rb.velocity.y < 0 && rb.velocity.y > minimumYVelocity)
        {
            float yVelocity = rb.velocity.y + Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            rb.velocity = new Vector2(rb.velocity.x, Math.Max(minimumYVelocity, yVelocity)); 
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

       
    }

    private void UpdateHealth()
    {
        hudManager.UpdateHealth(currentHealth);

        if (currentHealth <= 0 && !dead)
        {
            dead = true;
            PlayDeathAnimation();
        }
    }

    public void LoseHealth(int damage)
    {
        if (canTakeDamage)
        {
            animator.SetTrigger("Hurt");
            currentHealth -= damage;
            SetCanTakeDamage(false);
            StartCoroutine(AvoidDamageFor(avoidSeconds));
        }
    }

    private IEnumerator AvoidDamageFor(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SetCanTakeDamage(true);
        yield break;
    }

    private void SetCanTakeDamage(bool takeDamage)
    {
        canTakeDamage = takeDamage;
        animator.SetBool("CanBeDamaged", takeDamage);
    }

    public void PlayDeathAnimation()
    {
        UIManager.instance.ShowAlphaGray();
        rb.gravityScale = 0;
        rb.velocity = new Vector3(0, 0);
        cameraFollow.SetFollow(false); 
        animator.SetBool("Dead", true);
    }
}
