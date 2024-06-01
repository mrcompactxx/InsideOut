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
    private bool cutterCollided;
    public string potionName;
    [SerializeField]private Image HealthBar;
    private CoinsHandler coinsHandler;
    void Start()
    {
        coinsHandler = FindAnyObjectByType<CoinsHandler>();
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
        if (trap == "Bomb")
        {
            damage = 100f;
            HealthBar.fillAmount -= (damage / 100f) * Time.deltaTime;
        }
        if (cutterCollided) 
        {
            damage = 80f;
            HealthBar.fillAmount -= (damage / 100f) * Time.deltaTime;
        }
       
    }

    public void IncreaseHealth(string potionName) 
    {
        if (potionName=="Potion") 
        {
            heal = 1000f;
            HealthBar.fillAmount += (heal/100f)*Time.deltaTime;
        }
    }

    private void ReloadLevel() 
    {
        if (HealthBar.fillAmount<=0)
        {
            SceneManager.LoadScene(3);
            coinsHandler.amount = 0;
        }   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Path1")
        {
            SceneManager.LoadScene(4);
        }
      
        if (collision.gameObject.tag=="Cutter") 
        {
            cutterCollided = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cutter")
        {
            cutterCollided = false;
            
        }
    }
}
