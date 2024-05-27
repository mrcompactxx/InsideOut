using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerHandler2 : MonoBehaviour
{
    public bool isHurt;
    public string trapName;
    private float damage;
    private float heal;
    public string potionName;
    [SerializeField]private Image HealthBar;
    void Start()
    {

    }

    private void Update()
    {
        ReduceHealth(trapName);
        ReloadLevel();
    }

    

    public void ReduceHealth(string trap) 
    {
        if (trap == "Fire" && isHurt)
        {
            damage = 20f;
            HealthBar.fillAmount -= (damage / 100f) * Time.deltaTime;
        }
        if (trap == "Spikes" && isHurt)
        {
            damage = 40f;
            HealthBar.fillAmount -= (damage / 100f) * Time.deltaTime;
        }
        
    }

    public void IncreaseHealth(string potionName) 
    {
        if (potionName=="Health") 
        {
            heal = 100f;
            HealthBar.fillAmount += (heal/100f)*Time.deltaTime;
        }
    }

    private void ReloadLevel() 
    {
        if (HealthBar.fillAmount<=0)
        {
            SceneManager.LoadScene(2);
        }   
    }
}
