using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerHandler playerHandler;
    private Rigidbody2D playerRb;
    [SerializeField]private float speed= 10f;
    [SerializeField]private float jump= 14f;
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
            playerRb.velocity = new Vector2(speed , 0f);
        }
        else if (playerHandler.backwardIsPressed)
        {
            playerRb.velocity = new Vector2(-speed , 0f);
        }
        else if (playerHandler.jumpIsPressed) 
        {
            playerRb.velocity = new Vector2(0f,jump);
        }
    }
}
