using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    private bool isOnGround;
    private Rigidbody2D rb;

    private ForwardButton forwardButton;
    private BackwardButton backwardButton;
    private JumpButton jumpButton;

    private SpriteRenderer playerRenderer;
    private Animator animator;

    [SerializeField]private float speed;
    [SerializeField]private float jump;
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        forwardButton = FindAnyObjectByType<ForwardButton>();
        backwardButton = FindAnyObjectByType<BackwardButton>();
        jumpButton = FindAnyObjectByType<JumpButton>();
    }

    void Update()
    {
        Movement();
    }

    #region
    private void Movement() 
    {

        animator.SetBool("IsIdle", true);
        animator.SetBool("IsWalk", false);
        animator.SetBool("IsJump", false);

        if (forwardButton.isPressed)
        {
            playerRenderer.flipX = false;
            rb.velocity = new Vector2(speed, rb.velocity.y);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsWalk", true);
            animator.SetBool("IsJump", false);
        }

        if (backwardButton.isPressed) 
        {
            playerRenderer.flipX = true;
            rb.velocity = new Vector2((-speed),rb.velocity.y);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsWalk", true);
            animator.SetBool("IsJump", false);
        }
      
        if (jumpButton.isPressed)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsWalk", false);
            animator.SetBool("IsJump", true);
        }
        
    }
    #endregion

}

