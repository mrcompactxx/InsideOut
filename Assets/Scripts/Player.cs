using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private PlayerHandler playerHandler;
    private Rigidbody2D playerRb;
    private SpriteRenderer spriteRenderer;
    private bool isOnPlatform;
    public bool getIsOnPlatform 
    {
        get { return isOnPlatform; }
    }
    private bool powerSelected;
    public bool getPowerSelected 
    {
        get { return powerSelected; }
    }
    private string powerName;
    public string getPowerName 
    {
        get { return powerName; }
    }
    [SerializeField]private float speed= 10f;
    [SerializeField]private float jump= 25f;
    private bool isOnGround;
    private bool isHurt;
    public bool getIsHurt 
    {
        get { return isHurt; }
    }
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerRb = GetComponent<Rigidbody2D>();
        playerHandler = FindAnyObjectByType<PlayerHandler>();
    }

    void Update()
    {
        Movement();
   
    }

    private void Movement() 
    {
        if (playerHandler.forwardIsPressed)
        {
            spriteRenderer.flipX = false;
            playerRb.velocity = new Vector2(speed , playerRb.velocity.y);
        }
        if (playerHandler.backwardIsPressed)
        {
            spriteRenderer.flipX = true;
            playerRb.velocity = new Vector2(-speed , playerRb.velocity.y);
        }
        if (playerHandler.jumpIsPressed) 
        {
            if (isOnGround) 
            {
                playerRb.velocity = new Vector2(playerRb.velocity.x, jump);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Ground" || collision.gameObject.tag=="Platform") 
        {
            isOnGround = true;
        }
        if (collision.gameObject.tag=="Platform") 
        {
            isOnPlatform= true;
        }
        if (collision.gameObject.tag=="Rage") 
        {
            powerSelected = true;
            powerName = collision.gameObject.tag;
        }
        if (collision.gameObject.tag=="Calm") 
        {
            powerSelected = true;
            powerName = collision.gameObject.tag;
        }
        if (collision.gameObject.tag=="Slime") 
        {
            isHurt = true;
        }
       
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag=="Platform") 
        {
            isOnGround= false;
        }
        if (collision.gameObject.tag=="Slime") 
        {
            isHurt= false;
        }
    }


    
}
