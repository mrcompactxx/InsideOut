using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinAmount : MonoBehaviour
{
    [SerializeField]static int amount;
    private CoinManager manager;
    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        
        textMeshPro = FindAnyObjectByType<TextMeshProUGUI>();
        manager = FindAnyObjectByType<CoinManager>();
        
        amount = PlayerPrefs.GetInt("Level1Coins");
        textMeshPro.text = amount.ToString();
    }


    void Update()
    {

    }

    public void IncreaseAmount() 
    {
        amount = amount + 1;
        textMeshPro.text = $"{amount}";
    }



}
