using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PowerButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public bool isPressed;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData pointerEventData) 
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData pointerEventData) 
    {
        isPressed=false;
    }


}
