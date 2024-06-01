using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField ]private GameObject coin;
    private TextMeshProUGUI tmpro;
    [SerializeField]private GameObject[] coinSpawnPoints;
    public Animator animator;
    [SerializeField] private GameObject player;
    void Start()
    {
        if (coin==null) 
        {

            Resources.Load<GameObject>("Coin");
        }
        tmpro = FindAnyObjectByType<TextMeshProUGUI>();
        
        animator=GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject==player) 
        {
            OpenChest();
            for (int i = 0; i<5; i++) 
            {
                Instantiate(coin, coinSpawnPoints[i].transform.position, Quaternion.identity);

            }
        }
    }

    private void OpenChest() 
    {
        animator.SetBool("OpenChest",true);
    }
}
