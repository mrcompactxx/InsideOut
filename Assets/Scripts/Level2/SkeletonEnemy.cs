using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkeletonEnemy : MonoBehaviour
{
    [SerializeField]private Image healthBar;
    [SerializeField]private GameObject player;
    private Player1 player1;
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    [SerializeField] private Transform playerPos;
    private Rigidbody2D skeletonRb;
    private SpriteRenderer playerSpriteRenderer;
    private SpriteRenderer spriteRenderer;
    [SerializeField]private float speed = 5f;
    private bool reachedPoint1;
    private bool reachedPoint2;
    [SerializeField]private float distance1;
    [SerializeField] private float distance2;
    [SerializeField] private float playerDistance;
    private Animator animator;
    private bool playerArrived;
    private bool attacked;
    
    void Start()
    {
        player1  = FindAnyObjectByType<Player1>();
        animator = GetComponent<Animator>();
        skeletonRb = GetComponent<Rigidbody2D>();
        skeletonRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        distance1 = Vector3.Distance(this.transform.position, point1.position);
        distance2 = Vector3.Distance(this.transform.position, point2.position);
        playerDistance = Vector3.Distance(this.transform.position,playerPos.position) ;
        
        if (playerDistance>=5f) 
        {
            Walk(point1, point2);
        }
        Attack(playerPos);
        if (attacked) 
        {
            player1.ReduceHealth(20f);
        }
    }

    #region Walk(Transform point1,Transform point2)
    private void Walk(Transform point1, Transform point2)
    {
        animator.SetBool("isWalking", true);
        /* if (distance1 <= 2f)
         {
             speed = -speed;
             transform.position = Vector3.MoveTowards(transform.position, point2.position, (speed) * Time.deltaTime);
             reachedPoint1 = true;
             reachedPoint2 = false;
         }
         else
         {
             transform.position = Vector3.MoveTowards(transform.position, point1.position, speed * Time.deltaTime);

         }*/
 
        if (reachedPoint1 && !reachedPoint2)
        {
            spriteRenderer.flipX = false;
            transform.position = Vector3.MoveTowards(transform.position, point2.position, (speed) * Time.deltaTime);
            if (distance2 <= 2f)
            {
                reachedPoint2 = true;
                reachedPoint1 = false;
            }
        }
        else if (!reachedPoint1 && reachedPoint2)
        {
            spriteRenderer.flipX=true;
            transform.position = Vector3.MoveTowards(transform.position, point1.position,(speed) * Time.deltaTime);
            if (distance1<=2f) 
            {
                reachedPoint1=true;
                reachedPoint2 = false;
            }
        }
        else if (!reachedPoint1 && !reachedPoint2) 
        {

            transform.position = Vector3.MoveTowards(transform.position,point1.position,speed*Time.deltaTime);
            if (distance1 <=2f) 
            {
                reachedPoint1 = true;
                reachedPoint2 = false;
            }
        
        }

    }
    #endregion

    #region Attack(Transform playerPosition)
    private void Attack(Transform playerPosition)
    {

        if (playerDistance <= 5f)
        {
            if (transform.position.x < playerPos.position.x)
            {
                spriteRenderer.flipX = false;
            }
            else 
            {
                spriteRenderer.flipX = true;
            }

            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", true);
            animator.SetBool("isDead", false);
            
            transform.position = Vector3.MoveTowards(transform.position,playerPos.position,speed*Time.deltaTime);
        }
        else 
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isAttacking", false);
            animator.SetBool("isDead", false);
        }

    }


    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player") 
        {
            attacked = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player") 
        {
            attacked = false;
        }
    }
    public void ReduceHealth(float damage)
    {
        healthBar.fillAmount -= damage / 100f * Time.deltaTime;
        if (healthBar.fillAmount == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
