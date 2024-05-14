using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private bool isCollided;
    public bool isHurt;
    private Enemy enemyHandler;
    [SerializeField] public GameObject healthBarParent;
    private Player playerObject;
    [SerializeField] private Image healthBar;
    [SerializeField] private float damage;
    public bool getIsCollided 
    {
        get { return isCollided; }
    }
    void Start()
    {
        playerObject = FindAnyObjectByType<Player>();
        enemyHandler = FindAnyObjectByType<Enemy>();
    }

    void Update()
    {
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
            Destroy(collision.gameObject);
        }

    }


    public void HealthBar()
    {
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

}
