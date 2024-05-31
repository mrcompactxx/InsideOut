using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Coin : MonoBehaviour
{
    [SerializeField]private GameObject player;
    private CoinManager coinManager;
    public bool playerCollided;
    void Start()
    {
        coinManager = FindAnyObjectByType<CoinManager>();
    }

    void Update()
    {
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player") 
        {
            playerCollided = true;
            coinManager.IncreaseCoinAmount(1);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            playerCollided = false;
            
        }
    }


}
