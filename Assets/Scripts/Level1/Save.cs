using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    private CoinManager coinManager;
    private int coins;
    void Start()
    {
        coinManager = FindAnyObjectByType<CoinManager>();
        if (PlayerPrefs.GetInt("Coins")!=0) 
        {
            coins = PlayerPrefs.GetInt("Coins");
        }
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
                    
    }


}
