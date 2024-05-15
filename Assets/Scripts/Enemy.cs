using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private bool isCollided;
    private Animator enemyAnimator;
    [SerializeField] public GameObject healthBarParent;
    private Player playerObject;
    [SerializeField] public Image healthBar;
    [SerializeField]private GameObject deathEffect;
    [SerializeField] private float damage;
    public bool getIsCollided 
    {
        get { return isCollided; }
    }
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        playerObject = FindAnyObjectByType<Player>();
    }

    void Update()
    {
        PlayAnimations();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player") 
        {
            isCollided = true;
        }
      
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player") 
        {
            isCollided=false;
        }
    
    }


    public void HealthBar()
    {
        SetDamageValue();
        healthBar.fillAmount -= (damage/100f) ;
        if (healthBar.fillAmount < 0.4f)
        {
            healthBar.color = Color.red;
        }
    }

    public void SetDamageValue()
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

    private void PlayAnimations() 
    {
        if (isCollided == true)
        {
            enemyAnimator.SetBool("IsIdle", false);
            enemyAnimator.SetBool("IsAttacking", true);
        }
        else if (isCollided == false)
        {
            enemyAnimator.SetBool("IsIdle", true);
            enemyAnimator.SetBool("IsAttacking", false);
        }
    }

    public void Die() 
    {
        enemyAnimator.SetBool("EnemyDie",true);
        enemyAnimator.SetBool("IsIdle",false);
        enemyAnimator.SetBool("IsAttacking",false);
        Destroy(this.gameObject,0.5f);
    }
}
