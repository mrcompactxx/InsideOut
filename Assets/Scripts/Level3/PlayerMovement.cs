using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private ForwardButton forwardButton;
    private BackwardButton backwardButton;
    private JumpButton jumpButton;

    private Rigidbody2D rb;
    private float speed;
    private float jump;
    private bool onGround;  

    void Start()
    {
        speed = 10f;
        jump = 15f;
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
        if (forwardButton!=null && forwardButton.isPressed) 
        {
            rb.velocity = new Vector2(speed,rb.velocity.y);
        }
        if (backwardButton!=null && backwardButton.isPressed) 
        {
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

    private void EnableSadEmotion()
    {

    }
}
