using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public bool atPortal;
    public int amount;
    private PlayerHandler playerHandler;
    private Rigidbody2D playerRb;
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
    public bool isFlipped;

    public bool isOnTrapGround;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerHandler = FindAnyObjectByType<PlayerHandler>();
    }

    void Update()
    {
        Movement();
        if (playerHandler==null) 
        {
            playerHandler = FindAnyObjectByType<PlayerHandler>();
        }

        
    }
    #region Movement()
    private void Movement() 
    {
        if (playerHandler.forwardIsPressed && playerHandler != null)
        {
            Vector3 scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;   
            isFlipped = false;
            playerRb.velocity = new Vector2(speed , playerRb.velocity.y);
        }
        if (playerHandler.backwardIsPressed)
        {

            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
            isFlipped=true;
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
    #endregion
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Ground" || collision.gameObject.tag=="Platform" || collision.gameObject.tag == "TrapGround") 
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
        if (collision.gameObject.tag=="Slime"|| collision.gameObject.tag == "Trap") 
        {
            isHurt = true;
        }
        
        if (collision.gameObject.tag=="TrapGround") 
        {
            isOnTrapGround = true;
        }



    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag=="Platform"|| collision.gameObject.tag=="TrapGround") 
        {
            isOnGround= false;
        }
        if (collision.gameObject.tag=="Slime"|| collision.gameObject.tag == "Trap") 
        {
            isHurt= false;
        }
            
        if (collision.gameObject.tag == "TrapGround")
        {
            isOnTrapGround = false;
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Portal") 
        {
            atPortal = true;
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Portal")
        {
            atPortal = false;
        }

    }


}
