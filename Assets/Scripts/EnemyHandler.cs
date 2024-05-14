using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField]private GameObject slimeEnemy;
    [SerializeField] private GameObject player;
    private Player playerObject;
    private Enemy enemy;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField]private float distance;
    [SerializeField] private float speed=10f;
    [SerializeField]private GameObject healthBarParent;
    [SerializeField] private Image healthBar;
    [SerializeField] private float damage;
    private bool isHurt =false;
    void Start()
    {
        playerObject = FindAnyObjectByType<Player>();
        enemy = FindAnyObjectByType<Enemy>();
        slimeEnemy = this.gameObject.transform.GetChild(0).gameObject;       
        enemyAnimator = slimeEnemy.GetComponent<Animator>();
    }

    void Update()
    {
        Attack();
        if (enemy.isHurt) 
        {
            healthBarParent.SetActive(true);
            HealthBar(healthBar);
        }
    }

    private void Attack() 
    {
        distance = Vector2.Distance(slimeEnemy.transform.position, player.transform.position);
        if (distance < 15f)
        {
            slimeEnemy.transform.position = Vector2.MoveTowards(slimeEnemy.transform.position, player.transform.position, speed * Time.deltaTime);
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

    private void HealthBar(Image health) 
    {
        SetDamageValue();
        health.fillAmount -= (damage/100f) * Time.deltaTime;
        
        if (health.fillAmount<4f)
        {
            health.color = Color.red;
        }
    }

    private void SetDamageValue() 
    {
        if (playerObject.getPowerName == "Rage")
        {
            damage = 30f;
        }
        else if (playerObject.getPowerName == "Calm") 
        {
            damage = 10f;
        }
    }
}
