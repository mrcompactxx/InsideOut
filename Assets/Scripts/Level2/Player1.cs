using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
{
    public GameObject powerSelected;
    [SerializeField]private Image healthBar;
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
            transform.localScale = new Vector3(1,1,1);
            rb.velocity = new Vector2(speed, rb.velocity.y);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsWalk", true);
            animator.SetBool("IsJump", false);
            isFlipped = false;
        }

        if (backwardButton.isPressed) 
        {
            transform.localScale = new Vector3(-1,1,1);
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

    public void ReduceHealth(float damage)
    {
        healthBar.fillAmount -= damage/1000f*Time.deltaTime;
        if (healthBar.fillAmount==0) 
        {
            SceneManager.LoadScene(1);
        }
    }

}

