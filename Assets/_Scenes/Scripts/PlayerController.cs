using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //PlayerMovement Variables

    private float horizontal;

    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 15f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundDistance;

    private bool isFacingRight = true;
    public bool isJumping = false;
    private bool isGrounded = true;

    public Animator animator;

    //LayerChange Variables

    private float Up = 1.18f;
    private float Down = -1.18f;
    public float lane = 3f;

    //ScrollSpeed Variable

    public float scrollSpeed = 6f;

    [SerializeField] private float timeAlive = 6f;

    private void Start()
    {
        //PlayerMovement Code

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
        //PlayerMovement Code

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

        //LayerChange Code

        if (isJumping == false)
        {
            if (Input.GetKeyDown("w"))
            {
                transform.position += new Vector3(0, Up, 0);
                lane -= 1f;
            }

            if (Input.GetKeyDown("s"))
            {
                transform.position += new Vector3(0, Down, 0);
                lane += 1f;
            }

            if (lane <= 0f)
            {
                transform.position += new Vector3(0, Down, 0);
                lane += 1f;
            }

            if (lane >= 6f)
            {
                transform.position += new Vector3(0, Up, 0);
                lane -= 1f;
            }

            if (lane == 1f)
            {
                gameObject.layer = LayerMask.NameToLayer("Lane 1");
            }

            if (lane == 2f)
            {
                gameObject.layer = LayerMask.NameToLayer("Lane 2");
            }

            if (lane == 3f)
            {
                gameObject.layer = LayerMask.NameToLayer("Lane 3");
            }

            if (lane == 4f)
            {
                gameObject.layer = LayerMask.NameToLayer("Lane 4");
            }

            if (lane == 5f)
            {
                gameObject.layer = LayerMask.NameToLayer("Lane 5");
            }
        }

        //ScrollSpeed Code

        timeAlive += Time.deltaTime;

        transform.Translate(Vector2.left * Time.deltaTime * scrollSpeed);

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