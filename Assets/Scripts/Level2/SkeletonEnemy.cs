using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEnemy : MonoBehaviour
{

    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    [SerializeField] private Transform playerPos;
    private Rigidbody2D skeletonRb;
    private SpriteRenderer spriteRenderer;
    [SerializeField]private float speed = 5f;
    private bool reachedPoint1;
    private bool reachedPoint2;
    [SerializeField]private float distance1;
    [SerializeField] private float distance2;
    [SerializeField] private float playerDistance;
    private Animator animator;
    private bool playerArrived;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        skeletonRb = GetComponent<Rigidbody2D>();
        skeletonRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        distance1 = Vector3.Distance(this.transform.position, point1.position);
        distance2 = Vector3.Distance(this.transform.position, point2.position);
        playerDistance = Vector3.Distance(this.transform.position,playerPos.position) ;
        Walk(point1,point2);
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

    #region
    private void Attack(Transform playerPosition) 
    {
        if (playerDistance <= 5f)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", true);
            animator.SetBool("isDead", false);
        }
        else 
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isAttacking", false);
            animator.SetBool("isDead", false);
        }

    }


    #endregion


}
