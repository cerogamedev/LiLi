using UnityEngine;
using Lili.Core;
using Lili.Combat;
using System;
using System.Collections;

namespace Lili.Control {

    public class PlayerController : MonoBehaviour
    {
        // Configurable Variables
        #region  Configurable Params
        [Header("In Engine Configurable Params")]
        [SerializeField] float speed = 5f;
        [SerializeField] float jumpForce = 15f;
        #endregion
        #region  Dash Params
        private bool canDash = true;
        private bool IsDashing;
        [SerializeField] private float dashPower = 20f;
        [SerializeField] private float dashTime = 0.3f;
        private float dashCooldown = 1f;



        #endregion

        #region Components
        Animator animator;
        SpriteRenderer spriteRenderer;
        Rigidbody2D rb;

        #endregion
        #region CheckParams
        [Header("Check Params")]
        [SerializeField] LayerMask groundLayer;
        [SerializeField] Transform groundCheck;
        [SerializeField] Vector2 groundCheckSize;
        [SerializeField] Transform[] wallChecks;
        [SerializeField] Vector2 wallCheckSize;

        #endregion

        #region Checks
        int jumpCount = 2;
        #endregion
        private void Awake() {
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        private void Update() {
            Movement();
            AirAnimations();
            CollisionChecks();
            
        }

        private void CollisionChecks()
        {
            if (Physics2D.OverlapArea(groundCheck.position, groundCheckSize, groundLayer)){
                jumpCount = 2;

            }
        }

        private void AirAnimations()
        {
            if (rb.velocity.y > 0) {
                animator.SetBool("isRunning" , false);
                animator.SetBool("isJumping", true);
                animator.SetBool("isFalling", false);
            } else if (rb.velocity.y < 0) {
                animator.SetBool("isRunning" , false);
                animator.SetBool("isJumping", false);
                animator.SetBool("isFalling", true);
            } else if (rb.velocity.y == 0) {
                animator.SetBool("isJumping", false);
                animator.SetBool("isFalling", false);

            }
        }

        private void Jump()
        {
            if(Input.GetButtonDown("Jump") && jumpCount > 1) {
                rb.velocity += new Vector2(0, jumpForce - rb.velocity.y);
                jumpCount --;
            }
  
        }

        private void Movement()
        {
            Run();
            Jump();
            Dash();
        }

        private void Dash()
        {
            Vector2 dashDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (dashDirection == new Vector2(0,0)) { // If no input given dash forward
                if (spriteRenderer.flipX) {
                    dashDirection = new Vector2(-1,0);
                } else if(!spriteRenderer.flipX) {
                    dashDirection = new Vector2(1,0);
                }
            } 
            if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            {
                StartCoroutine(DashBehaviour(dashDirection));
            }
        }

        private IEnumerator DashBehaviour(Vector2 dashRotation)
        {
            canDash = false;
            IsDashing = true; // We may use this later.
            float originalGravity = rb.gravityScale;
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(transform.localScale.x * dashRotation[0] * dashPower, transform.localScale.y * dashRotation[1] * dashPower);
            yield return new WaitForSeconds(dashTime);
            rb.gravityScale = originalGravity;
            rb.velocity = new Vector2(0, transform.localScale.y);
            IsDashing = false;
            yield return new WaitForSeconds(dashCooldown);
            canDash = true;
        }

        private void Run()
        {
            Input.GetAxisRaw("Horizontal");
            float velocity = Input.GetAxisRaw("Horizontal");
            if (velocity < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (velocity > 0)
            {
                spriteRenderer.flipX = false;
            }
            transform.Translate(velocity, 0, 0);
            if (velocity != 0)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }
    }
}

