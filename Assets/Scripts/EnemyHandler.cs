using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField]private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private GameObject enemy;
    [SerializeField]private float distance;
    void Start()
    {
        speed = 8f;
    }

    void Update()
    {
        if (enemy != null) 
        {
            distance = Vector2.Distance(enemy.transform.position, player.transform.position);
            if (distance <= 15f)
            {
                enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }
        
    }
      
       
    
  
      
}
