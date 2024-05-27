using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHandler2 : MonoBehaviour
{
    [SerializeField]private SpriteRenderer spriteRenderer;
    
    private ForwardButton forwardButton;

    void Start()
    {
        forwardButton = FindAnyObjectByType<ForwardButton>();
    }

}
