using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePower : MonoBehaviour
{
    private bool collidedWithEnemy;
    private float speed;
    private Rigidbody2D rb;
    [SerializeField]private GameObject player;
    private Vector3 scaleCheck = new Vector3 (1, 1, 1);
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        speed = 23f;
        rb = GetComponent<Rigidbody2D>();
        if (player.transform.localScale == scaleCheck)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }

    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Enemy" || collision.gameObject.tag=="Trap") 
        {
            Destroy(gameObject);
        
        }
        Destroy(gameObject);
    }
}
