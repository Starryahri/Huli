using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Char_Controller_Test : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    [SerializeField] private float RunSpeed = 50f;
    [SerializeField] private float JumpForce = 100f;
    private float HorizontalMove = 0f;
    private float Horizontal = 0f;
    [HideInInspector] public bool FacingRight = true;
    [HideInInspector] public bool IsJumping = false;
    [HideInInspector] public bool IsGrounded;
    [HideInInspector] public bool WallCollision = false;
    [SerializeField] private Animator animator;

    [HideInInspector] public bool DoubleJump = false;
    private float DoubleTrail = 0f;
    public GameObject DoubleJumpPoof;
    public GameObject DoubleJumpTrail;
    public ThrowDash Throw;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

private void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));
        animator.SetBool("Grounded", IsGrounded);

        if (IsGrounded)
        {
            Throw.Throwable = true;
        }

        //Jump input
        if (Input.GetButtonDown("Jump"))
        {
            IsJumping = true;
        }
        if (Input.GetButtonUp("Jump"))
        {
            IsJumping = false;
        }

        //Walk input
        Horizontal = Input.GetAxisRaw("Horizontal");

        
    }



    void FixedUpdate()
    {
        if (DoubleTrail > 0)
        {
            DoubleTrail -= Time.fixedDeltaTime;
            GameObject JumpTrail = Instantiate(DoubleJumpTrail, new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z), Quaternion.identity);
            Destroy(JumpTrail, 3f);
        }

        //Horizontal movement
        if (WallCollision == true)
        {
            HorizontalMove = 0;
        }

        if (WallCollision == false)
        {
            HorizontalMove = Horizontal * RunSpeed * Time.fixedDeltaTime;
        }

        

        // Running movement
        rigidbody2d.velocity = new Vector2(HorizontalMove, rigidbody2d.velocity.y);

        // Flipping the player to face the direction of movement
        if (Horizontal > 0 && !FacingRight)
        {
            Flip();
        }
        else if (Horizontal < 0 && FacingRight)
        {
            Flip();
        }

        // Jumping
        if (IsJumping == true && IsGrounded == true)
        {
            rigidbody2d.velocity = new Vector2(0, JumpForce * Time.fixedDeltaTime);
            IsJumping = false;
        }

        if (IsJumping == true && IsGrounded == false && DoubleJump == false)
        {
            rigidbody2d.velocity = new Vector2(0, JumpForce * 1.2f * Time.fixedDeltaTime);
            DoubleJump = true;
            GameObject JumpPoof = Instantiate(DoubleJumpPoof, new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z), Quaternion.identity);
            Destroy(JumpPoof, 3f);
            DoubleTrail = 0.35f;
            animator.SetTrigger("Double");
        }

    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing
        FacingRight = !FacingRight;

        // Multiply the player's x scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
