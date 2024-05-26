using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
{
    [SerializeField]private Transform teleportLocation;
    public GameObject powerSelected;
    [SerializeField]private Image healthBar;
    private bool isOnGround;
    private Rigidbody2D rb;
    private bool collidedWithTrap;

    private ForwardButton forwardButton;
    private BackwardButton backwardButton;
    private JumpButton jumpButton;

    private Animator animator;
    private GameObject power;
    [SerializeField]private GameObject powerButton;
    public bool isFlipped;
    [SerializeField]private float speed;
    [SerializeField]private float jump;
    private bool enabledButton;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        forwardButton = FindAnyObjectByType<ForwardButton>();
        backwardButton = FindAnyObjectByType<BackwardButton>();
        jumpButton = FindAnyObjectByType<JumpButton>();
    }

    void Update()
    {
        
        if (power!=null && !enabledButton) 
        {
            powerButton.SetActive(true);
            enabledButton = true;
        }
        if (collidedWithTrap) 
        {
            ReduceHealth(80);
        }
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
        if (collision.gameObject.tag=="Teleport") 
        {
            transform.position = new Vector3(teleportLocation.transform.position.x,teleportLocation.transform.position.y+2,teleportLocation.transform.position.z);
        }
        if (collision.gameObject.tag=="Calm") 
        {
            power = Resources.Load<GameObject>(collision.gameObject.tag);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag=="Trap") 
        {
            collidedWithTrap = true;
        }
        if (collision.gameObject.tag == "Portal")
        {
            SceneManager.LoadScene(2);
            }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Ground") 
        {
            isOnGround= false;
        }
        if (collision.gameObject.tag=="Trap") 
        {
            collidedWithTrap= false;
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

