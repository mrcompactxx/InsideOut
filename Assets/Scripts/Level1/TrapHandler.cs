using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapHandler : MonoBehaviour
{
    [SerializeField]private GameObject plantTrap;
    Rigidbody2D rigidBody;
    private bool isOnGround;
    [SerializeField]private float jump;
    private Animator animator;
    private bool collidedWithPlayer;
    private bool isHurt;
    private GameObject power;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        jump = 10f;
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent <SpriteRenderer>();
        animator = GetComponent <Animator>();
    }

    void Update()
    {
        if (rigidBody != null && isOnGround) 
        {
            Jump();
        }
        Erupt(collidedWithPlayer);
        DestroyPower(isHurt);
    }

    private void Jump() 
    {
        rigidBody.velocity = new Vector2(0,jump);
    }

    private void Erupt(bool collided) 
    {
        if (collided) 
        {
            spriteRenderer.color = Color.red;
            StartCoroutine(DestroyPlantTrap());
        }

    }

    IEnumerator DestroyPlantTrap() 
    {
        
        animator.SetBool("Erupt",true);
        gameObject.transform.localScale = new Vector3(3,3,3);
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
        
    }

    private void DestroyPower(bool isHurt)
    {
        if (isHurt)
        {
            this.gameObject.transform.localScale = new Vector3(3,3,3);
            animator.SetBool("Erupt", true);
            Destroy(gameObject,1);
            Destroy(power.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Ground") 
        {
            isOnGround = true;
        }
        if (collision.gameObject.tag=="Player") 
        {
            collidedWithPlayer = true;
        }
        if (collision.gameObject.tag == "Rage"|| collision.gameObject.tag=="Calm")
        {
            power = collision.gameObject;
            isHurt = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Ground") 
        {
            isOnGround= false;
        }
        if (collision.gameObject.tag == "Player")
        {
            collidedWithPlayer = false;
        }
        if (collision.gameObject.tag=="Rage"|| collision.gameObject.tag=="Calm") 
        {
            isHurt = false;
        }

    }

}

