using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerHandler playerHandler;
    private Rigidbody2D playerRb;
    [SerializeField]private float speed= 10f;
    [SerializeField]private float jump= 25f;
    [SerializeField]private bool isOnGround;
    void Start()
    {
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
            playerRb.velocity = new Vector2(speed , playerRb.velocity.y);
        }
        if (playerHandler.backwardIsPressed)
        {
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
        if (collision.gameObject.tag=="Ground") 
        {
            isOnGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") 
        {
            isOnGround= false;
        }
    }

    
}
