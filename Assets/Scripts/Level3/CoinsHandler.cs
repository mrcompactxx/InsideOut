using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsHandler : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    void Start()
    {
        textMeshPro = FindAnyObjectByType<TextMeshProUGUI>();
        textMeshPro.text = $"{PlayerPrefs.GetInt("Level2Coins")}";
    }

    void Update()
    {
        
    }
}
