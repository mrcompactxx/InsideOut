using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin2 : MonoBehaviour
{
    private CoinAmount coinAmount;
    void Start()
    {
        coinAmount = FindAnyObjectByType<CoinAmount>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            coinAmount.IncreaseAmount();
            Destroy(gameObject);
        }
    }
}
