using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Coin : MonoBehaviour
{
    public TextMeshProUGUI text;
    [SerializeField]private GameObject player;
    [SerializeField]private AudioSource audioSource;
    private CoinManager coinManager;
    private bool playerCollided;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            audioSource.Play();
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
