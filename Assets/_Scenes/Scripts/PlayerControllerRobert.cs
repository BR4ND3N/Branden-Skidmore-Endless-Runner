using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRobert : MonoBehaviour
{
    public Rigidbody2D PlayerRB;
    public float jumpForce;

    [SerializeField] private Transform feetPosition;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float jumpTime = 0.25f;

    private bool isGrounded = true;
    private bool isJumping = false;
    private float jumpTimer;

    //Update is called once per frame
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundDistance, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            PlayerRB.velocity = Vector2.up * jumpForce;
            isGrounded = false;
            isJumping = true;
        }

        if(isJumping == true && Input.GetButton("Jump"))
        {
            if(jumpTimer < jumpTime)
            {
                PlayerRB.velocity = Vector2.up * jumpForce;

                jumpTimer += Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
    }
}