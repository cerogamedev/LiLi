using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AnimationController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private bool isBowAttacking, isBowGoing;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    private enum MovementState { idle, running, jumping, falling}

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);


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

        if (Mathf.Abs(moveInput) > 0.2f)
        {
            state = MovementState.running;
        }
        else
            state = MovementState.idle;

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

