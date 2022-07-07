using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float energyfuller;
    
    
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX = 0f;
    public float activeMovespeed = 13f;

    public float jumpNumber = 0;
    public float jumpLimit;
    public float energy = 0.007f;

    public float dashSpeed;
    public float dashLenght = .5f, dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;

    [SerializeField] private LayerMask jumpableGround;


    [SerializeField] ParticleSystem dust;
    private ParticleSystem.EmissionModule footEmission;

    private enum MovementState {idle, running, jumping, falling, fighting }


    public EnergyBar energyBar;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    private bool isJumping;


    // Start is called before the first frame update
    private void Start()
    {
        footEmission = dust.emission;

        
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();

        energyBar.SetMaxEnergy(jumpLimit);
    }

    // Update is called once per frame
    private void Update()
    {
        dusteffect();
        
                
        energy = jumpLimit - jumpNumber;

        energyBar.SetEnergy(energy);





        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * activeMovespeed, rb.velocity.y);


        //jump with coyote
        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;

        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f && !isJumping && (jumpNumber<jumpLimit))
        {
            rb.velocity = new Vector2(rb.velocity.x, 25f);
            jumpNumber++;

            jumpBufferCounter = 0f;

            StartCoroutine(JumpCooldown());
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        }



        UpdateAnimationUpdate();

        //dash
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (dashCoolCounter<=0 && dashCounter<=0 && (jumpNumber < jumpLimit))
            {
                activeMovespeed = dashSpeed;
                dashCounter = dashLenght;
                jumpNumber += 2;
            }
        }
        if (dashCounter>0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter<=0)
            {
                activeMovespeed = 13f;
                dashCoolCounter = dashCooldown;
            }
        }
        if (dashCoolCounter>0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
        //pet dash speed

        if (Butterflypet.petTrigger ==1)
        {
            dashSpeed = 80f;
        }


        //energy fuller
        if (Input.GetKey(KeyCode.LeftControl) && dirX == 0 && IsGrounded())
        {
            if (energy<=jumpLimit)
            {
                jumpNumber = jumpNumber - energyfuller;
                anim.SetTrigger("Meditasion");

            }

        }

        if (dirX < 0)
        {
            jumpNumber += 0.0004f;
        }
        if (dirX > 0)
        {
            jumpNumber += 0.0004f;
        }
    }



    private void UpdateAnimationUpdate()
    {
        float dirX = Input.GetAxisRaw("Horizontal");

        MovementState state;
        
        
 
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.2f)
        {
            state = MovementState.falling;
        }
        

        anim.SetInteger("state", (int)state);


    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    void dusteffect()
    {
        if (Input.GetAxisRaw("Horizontal")!= 0 && IsGrounded())
        {
            footEmission.rateOverTime = 35f;
        }
        else
        {
            footEmission.rateOverTime = 0f;
        }
    }


    private IEnumerator JumpCooldown()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.4f);
        isJumping = false;
    }
}
