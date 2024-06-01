using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsHandler : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    public int amount;
    void Start()
    {
        textMeshPro = FindAnyObjectByType<TextMeshProUGUI>();
        amount = PlayerPrefs.GetInt("Level2Coins");
        textMeshPro.text = amount.ToString();
        

    }

    void Update()
    {
        PlayerPrefs.SetInt("Level3Coins",amount);
    }

    public void IncreaseAmount() 
    {
        amount = amount + 1;
        textMeshPro.text = amount.ToString();

    }
}
