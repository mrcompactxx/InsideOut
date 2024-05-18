using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    private bool isOnGround;
    [SerializeField]private Rigidbody2D rigidBody;
    private Player player;
    private bool destroySpike;
    [SerializeField]private float speed;
    void Start()
    {
        speed = 0.03f;
        rigidBody = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<Player>();
    }

    void Update()
    {
        isOnGround = player.isOnTragGround;
        Attack(isOnGround);

        
    }

    private void Attack(bool isOnGround) 
    {
        if (isOnGround)
        {
            rigidBody.velocity += new Vector2(rigidBody.velocity.x, -speed);
            if (destroySpike)
            {
                Destroy(this.gameObject,0.2f);
            }
        }
        
        
    }
        
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="TrapGround") 
        {
            destroySpike = true;
        }
        if (collision.gameObject.tag=="Player") 
        {
            destroySpike= true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TrapGround")
        {
            destroySpike = false;
        }

    }


}
