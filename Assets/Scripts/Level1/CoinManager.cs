using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
    public int amt 
    {
        get { return amount; }
        set { amount = value; }
    }
    [SerializeField]public int amount;
    [SerializeField]private TextMeshProUGUI text;

    void Start()
    {
        text = FindAnyObjectByType<TextMeshProUGUI>();
        if (PlayerPrefs.GetInt("Coins") != 0 && SceneManager.GetActiveScene().buildIndex != 1)
        {
            amount = PlayerPrefs.GetInt("Coins");
        }
        else 
        {
            PlayerPrefs.SetInt("Coins",0);
        }

    }

    void Update()
    {
        PlayerPrefs.SetInt("Coins",amount);
        PlayerPrefs.SetInt("Level1Coins",amount);
        if(text==null)
        {
            text = FindAnyObjectByType<TextMeshProUGUI>();
        }
    }
    public void IncreaseCoinAmount(int amt)
    {
        amount = amount + amt;
        text.text = $"{amount}";
    }
}
