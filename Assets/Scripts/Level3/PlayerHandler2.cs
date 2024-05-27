using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHandler2 : MonoBehaviour
{
    public bool isHurt;
    public string trapName;
    public float damage;
    [SerializeField]private Image HealthBar;
    void Start()
    {

    }

    private void Update()
    {
    }

    

    public void ReduceHealth(string trap) 
    {
        if (trap == "Fire" && isHurt)
        {
            damage =20f;
            HealthBar.fillAmount = (damage / 100f)*Time.deltaTime;
        }
        else if (trap=="Spike" && isHurt) 
        {
            damage = 40f;
            HealthBar.fillAmount = (damage/100f)*Time.deltaTime;
        }
    }
}
