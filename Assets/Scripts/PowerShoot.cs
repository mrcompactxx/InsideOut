using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerShoot : MonoBehaviour
{
    private bool shoot;
    private bool collidedWithEnemy;
    public bool getCollidedWithEnemy 
    {
        get { return collidedWithEnemy; }
    }
    private Player player;
    private PlayerHandler playerHandler;
    private PowerButton powerButton;
    private Enemy enemy;
    [SerializeField]private GameObject powerLocation;
    [SerializeField]private GameObject prefab;
    private GameObject power;
    [SerializeField]private float powerSpeed;
    void Start()
    {
        player = FindAnyObjectByType<Player>();
        playerHandler = FindAnyObjectByType<PlayerHandler>();
        powerButton = FindAnyObjectByType<PowerButton>();
        enemy = FindAnyObjectByType<Enemy>();   
    }

    void Update()
    {
        if (powerButton == null) 
        {
            powerButton = FindAnyObjectByType<PowerButton>();
        }

        if (GetPower(playerHandler)) 
        {
            if (powerButton!=null) 
            {
                Attack();
            }
            
        }
    }

    private bool GetPower(PlayerHandler playerHandler) 
    {
        if (player.getPowerName != null)
        {
            prefab = playerHandler.getPower();
            return true;
        }
        else 
        {
            return false;
        }
        
    }

    private void Attack() 
    {


        Rigidbody2D rb;
        if (shoot == false && powerButton.isPressed)
        {
            power = Instantiate(prefab, powerLocation.transform.position, Quaternion.identity);
            rb = power.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(powerSpeed, rb.velocity.y);


              
            
            shoot = true;
        
        }
        else if (shoot == true && powerButton.isPressed == false)
        {
            shoot = false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
