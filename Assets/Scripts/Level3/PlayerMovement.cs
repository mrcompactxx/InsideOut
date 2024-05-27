using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private ForwardButton forwardButton;
    private BackwardButton backwardButton;
    private JumpButton jumpButton;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    [SerializeField]private float speed;
    [SerializeField]private float jump;
    private bool onGround;  

    void Start()
    {
        speed = 10f;
        jump = 15f;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); 
        forwardButton = FindAnyObjectByType<ForwardButton>();
        backwardButton = FindAnyObjectByType<BackwardButton>();
        jumpButton = FindAnyObjectByType<JumpButton>();
    }

    void Update()
    {
        Movement();
    }


    private void Movement() 
    {
        EnableAnimations();
        if (forwardButton!=null && forwardButton.isPressed) 
        {
            spriteRenderer.flipX = false ;
            rb.velocity = new Vector2(speed,rb.velocity.y);
        }
        if (backwardButton!=null && backwardButton.isPressed) 
        {
            spriteRenderer.flipX = true;
            rb.velocity = new Vector2(-speed,rb.velocity.y);
        }
        if (jumpButton!=null && jumpButton.isPressed && onGround) 
        {
            rb.velocity = new Vector2(rb.velocity.x,jump);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
    }

    private void EnableAnimations()
    {
        animator.SetBool("IsIdle", true);
        animator.SetBool("IsWalk", false);
        animator.SetBool("IsJump", false);
        if (forwardButton.isPressed)
        {
            animator.SetBool("IsWalk", true);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsJump", false);
        }
        else if (backwardButton.isPressed)
        {
            animator.SetBool("IsWalk", true);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsJump", false);
        }
        else if (jumpButton.isPressed)
        {
            animator.SetBool("IsWalk", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsJump", true);
        }

    }
    private void EnableSadEmotion()
    {

    }
}
