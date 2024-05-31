using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy1 : MonoBehaviour
{
    private bool collidedPlayer;
    private Animator animator;
    [SerializeField]private GameObject player;
    private Player1 player1;
    [SerializeField]private float speed;
    private bool hurt;
    private float damage;
    [SerializeField]private Image healthBar;
    private SpriteRenderer spriteRenderer;
    [SerializeField]private GameObject healthBarParent;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player1 = FindAnyObjectByType<Player1>();
        animator = GetComponent<Animator>();
        speed = 5f;
        healthBarParent.SetActive(false);
    }

    void Update()
    {
        Attack();
    }

    private void Attack() 
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance<10f) 
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed*Time.deltaTime);
        }
        if (collidedPlayer) 
        {
            player1.ReduceHealth(45);
        }
        if (hurt) 
        {
            healthBarParent.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player") 
        {
            collidedPlayer = true;
        }
        if (collision.gameObject.tag=="Calm") 
        {
            hurt = true;
            ReduceHealth(hurt);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collidedPlayer = false;
        }
        if (collision.gameObject.tag=="Calm") 
        {
            hurt = false;
        }
    }

    private void ReduceHealth(bool isHurt) 
    {
        StartCoroutine(changeColor());
        damage = 220f;
        healthBar.fillAmount -=(damage/100)*Time.deltaTime;

        if (healthBar.fillAmount==0) 
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator changeColor() 
    {
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(0.4f);
        spriteRenderer.color = Color.red;
    }

}
