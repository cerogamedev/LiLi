using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AnimationController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    public int animationContol;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    private enum MovementState { idle, running, jumping, falling }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float moveInput = Input.GetAxis("Horizontal");


        if (isGrounded && Mathf.Abs(moveInput) >= 0.3f)
        {
            animationContol = 1;
        }
        else if (isGrounded)
            animationContol = 0;
        if (rb.velocity.y > .1f && !isGrounded)
            animationContol = 2;
        else if (rb.velocity.y < .1f && !isGrounded)
            animationContol = 3;
    }
    private void FixedUpdate()
    {
        UpdateAnimationState();
    }
    private void UpdateAnimationState()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float moveInput = Input.GetAxis("Horizontal");

        MovementState state;

        if (Mathf.Abs( moveInput) > 0.2f)
        {
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("AnimCont", (int)state);
    }
}

