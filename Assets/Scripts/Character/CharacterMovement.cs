using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    private Rigidbody2D rb;
    private Collision coll;

    public float speed;
    public float jumpForce;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collision>();
    }

    // Update is called once per frame
    void Update () {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(x, y);
        Walk(dir);

        if (Input.GetButtonDown("Jump"))
        {
           if (coll.onGround)
                Jump(Vector2.up);
        }
    }

    private void Walk(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
    }

    private void Jump(Vector2 dir)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpForce;
    }

}
