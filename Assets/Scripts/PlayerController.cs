using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D controller;
    Animator playerAnimation;

    [Header("Movement Settings")]
    public float speed = 8f;
    public float jumpForce = 5f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    [Header("Ground Checking")]
    bool isGrounded = false;
    public float rememberGroundedFor;
    float lastTimeGrounded;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    void Start()
    {
        controller = GetComponent<Rigidbody2D>();   
        playerAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
        CheckIfGrounded();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        controller.velocity = new Vector2(moveBy, controller.velocity.y);

        if (x > 0)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        else if (x < 0)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }

        if (isGrounded && (x < 0 || x > 0))
        {
            playerAnimation.SetBool("isRunning", true);
        }
        else
        {
            playerAnimation.SetBool("isRunning", false);
        }
    }

    void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor))
        {
            controller.velocity = new Vector2(controller.velocity.x, jumpForce);
        }

        if (controller.velocity.y < 0)
        {
            controller.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (controller.velocity.y > 0)
        {
            controller.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if (collider != null)
        {
            isGrounded = true;
            playerAnimation.SetBool("isJumping", false);
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }

            playerAnimation.SetBool("isJumping", true);
            isGrounded = false;
        }
    }
}
