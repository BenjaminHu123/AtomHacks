using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour {

    Animator animator;
    Rigidbody2D myRigidBody;
    SpriteRenderer spriteRenderer;

    bool isGrounded;
    bool facingRight = true;

    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    Transform groundCheckR;
    [SerializeField]
    Transform groundCheckL;
    [SerializeField]
    private float runSpeed = 1.5f;
    [SerializeField]
    private float jumpSpeed = 5f;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void FixedUpdate () {

        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground")))
            isGrounded = true;
        else {
            isGrounded = false;
        }
        float horizontal = Input.GetAxis("Horizontal");
        Flip(horizontal);
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            myRigidBody.velocity = new Vector2(runSpeed, myRigidBody.velocity.y);
            if (isGrounded)
                animator.Play("WalkKnight");
            //spriteRenderer.flipX = false;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            myRigidBody.velocity = new Vector2(-1 * runSpeed, myRigidBody.velocity.y);
            if (isGrounded)
                animator.Play("WalkKnight");
           // spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.Z) && isGrounded) {
            animator.SetTrigger("attack");
        }
        else {
            if (isGrounded)
                animator.Play("IdleKnight");
            myRigidBody.velocity = new Vector2(0, myRigidBody.velocity.y);
        }
        if (Input.GetKey("space") && isGrounded)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpSpeed);
            animator.Play("JumpKnight");
        }
        if(!isGrounded && myRigidBody.velocity.y < 0)
            animator.Play("FallKnight");
    }
    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

}
