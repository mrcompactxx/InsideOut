using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public GameObject powerSelected;

    private bool isOnGround;
    private Rigidbody2D rb;

    private ForwardButton forwardButton;
    private BackwardButton backwardButton;
    private JumpButton jumpButton;

    private SpriteRenderer playerRenderer;
    private Animator animator;

    public bool isFlipped;
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
            isFlipped = false;
        }

        if (backwardButton.isPressed) 
        {
            playerRenderer.flipX = true;
            rb.velocity = new Vector2((-speed),rb.velocity.y);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsWalk", true);
            animator.SetBool("IsJump", false);
            isFlipped = true;
        }

        if (jumpButton.isPressed && isOnGround)
        {

            rb.velocity = new Vector2(rb.velocity.x, jump);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsWalk", false);
            animator.SetBool("IsJump", true);

        }
       
        
    }
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Ground")
        {
                isOnGround = true;
        }
        if (collision.gameObject.tag=="Summon") 
        {
            powerSelected = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Ground") 
        {
            isOnGround= false;
        }
       
    }

}

