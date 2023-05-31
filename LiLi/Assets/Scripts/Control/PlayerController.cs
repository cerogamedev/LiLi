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
        [SerializeField] float dashForce = 50f;
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
        float directionX = 1;
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
            StartCoroutine(Dash());
        }

        private IEnumerator Dash()
        {
            if(Input.GetKeyDown(KeyCode.LeftShift)) {
                rb.velocity += new Vector2(dashForce*directionX - rb.velocity.x ,0);
                yield return new WaitForSeconds(0.2f);
                rb.velocity -= new Vector2(dashForce*directionX,0);
            } else yield return null;
        }

        private void Run()
        {
            directionX = Input.GetAxisRaw("Horizontal");
            float velocity = directionX * speed * Time.deltaTime;
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

