using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;

    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundDistance;

    private bool isFacingRight = true;
    public bool isJumping = false;
    private bool isGrounded = true;

    private float Up = 1.18f;
    private float Down = -1.18f;

    public Animator animator;

    public LayerChange layerChange;

    private void Start()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundLayer) == true)
        {
            isGrounded = true;
            isJumping = false;
        }

        else
        {
            isGrounded = false;
            isJumping = true;
        }
    }

    void Update()
    {
        if(Input.GetButton("Horizontal"))
        {
            animator.SetFloat("Moving", 0.01f);
        }
        if(Input.GetButtonUp("Horizontal"))
        {
            animator.SetFloat("Moving", 0.0f);
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetBool("IsJumping", true);
        }

        if (Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundLayer) == true)
        {
            isGrounded = true;
            isJumping = false;
        }

        else
        {
            isGrounded = false;
            isJumping = true;
        }

        if (isGrounded == false)
        {
            animator.SetBool("IsJumping", true);
        }

        if (isGrounded == true)
        {
            animator.SetBool("IsJumping", false);
        }
        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }


    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}