using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Animator animator;
    [SerializeField]private float speed;
    private PlayerHandler2 playerHandler;
    private bool playerArrived;
    void Start()
    {
        playerHandler = FindAnyObjectByType<PlayerHandler2>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerArrived) 
        {
            Explode();
            playerHandler.isHurt = playerArrived;
            playerHandler.ReduceHealth(gameObject.tag);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player") 
        {
            playerArrived = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerArrived = false;
        }
    }

    private void Explode() 
    {
        transform.localScale = new Vector3(15,15,15);
        animator.SetBool("Explode",true);
        Destroy(gameObject,1f);
    }
}
