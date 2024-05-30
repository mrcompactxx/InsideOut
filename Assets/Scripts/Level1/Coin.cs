using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Coin : MonoBehaviour
{
    public TextMeshProUGUI text;
    [SerializeField]private GameObject player;
    private CoinManager coinManager;
    private bool playerCollided;
    void Start()
    {
        text = FindAnyObjectByType<TextMeshProUGUI>();
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
            coinManager.amount = coinManager.amount + 1;
            IncreaseCoinAmount();
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

    private void IncreaseCoinAmount() 
    {
        text.text = $"{coinManager.amount}";
    }
}
