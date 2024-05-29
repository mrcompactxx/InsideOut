using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pathspawner : MonoBehaviour
{
    private GameObject portal;
    [SerializeField]private GameObject[] lamps;
    private SpriteRenderer[] sprites = new SpriteRenderer[10];
    private bool lamp1,lamp2,lamp3,lamp4;
    [SerializeField]private GameObject spawnLocation;
    private bool portalSpawned;
    private Vector3 offset;
    void Start()
    {
        offset = new Vector3 (0, 3f, 0);
        portal = Resources.Load<GameObject>("Portal").transform.GetChild(0).gameObject;
        for (int i=0;i<4;i++) 
        {
            sprites[i] = lamps[i].gameObject.GetComponent<SpriteRenderer>();
        }
    }

    void Update()
    {
        OpenPortal();

        if (lamp1)
        {
            sprites[0].color = Color.white;
        }
        if (lamp2) 
        {
            sprites[1].color = Color.white;
        }
        if (lamp3)
        {
            sprites[2].color = Color.white;
        }
        if (lamp4)
        {
            sprites[3].color = Color.white;
        }
    }


    #region trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name=="Fire") 
        {
            SceneManager.LoadScene(3);
        }
        if (collision.gameObject.tag=="Portal") 
        {
            SceneManager.LoadScene(0);
        }
        if (collision.gameObject.tag == lamps[0].gameObject.tag)
        {
            sprites[0].color = Color.white;
            lamp1 = true;
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                sprites[i].color = Color.black;
            }
        }
        if (collision.gameObject.tag == lamps[1].gameObject.tag && lamp1)
        {
            sprites[1].color = Color.white;
            lamp2 = true;
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                sprites[i].color = Color.black;
            }
        }
        if (collision.gameObject.tag == lamps[2].gameObject.tag && lamp2)
        {
            sprites[2].color = Color.white;
            lamp3 = true;
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                sprites[i].color = Color.black;
            }
        }
        if (collision.gameObject.tag == lamps[3].gameObject.tag && lamp3)
        {
            sprites[3].color = Color.white;
            lamp4 = true;
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                sprites[i].color = Color.black;
            }
        }
    }
    #endregion
    private void OpenPortal() 
    {
        if (lamp4 && !portalSpawned) 
        {
            GameObject portalPrefab = Instantiate(portal,new Vector3(spawnLocation.transform.position.x+offset.x,spawnLocation.transform.position.y+offset.y,-8.16f),Quaternion.identity);
            portalPrefab.transform.localScale = new Vector3(2,2,2);
            portalSpawned = true;
        }
    }
}
