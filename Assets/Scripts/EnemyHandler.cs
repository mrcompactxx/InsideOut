using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField]private GameObject slimeEnemy;
    [SerializeField] private GameObject player;
    private Enemy enemy;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField]private float distance;
    [SerializeField] private float speed=10f;
    void Start()
    {
        enemy = FindAnyObjectByType<Enemy>();
        slimeEnemy = this.gameObject.transform.GetChild(0).gameObject;       
        enemyAnimator = slimeEnemy.GetComponent<Animator>();
    }

    void Update()
    {
        distance = Vector2.Distance(slimeEnemy.transform.position, player.transform.position);
        if (distance<15f) 
        {
            slimeEnemy.transform.position = Vector2.MoveTowards(slimeEnemy.transform.position,player.transform.position,speed*Time.deltaTime);
            if (enemy.getIsCollided)
            {
                enemyAnimator.SetBool("IsIdle", false);
                enemyAnimator.SetBool("IsAttacking", true);
            }
            else 
            {
                enemyAnimator.SetBool("IsIdle", true);
                enemyAnimator.SetBool("IsAttacking", false);
            }
        }
    }

   
}
