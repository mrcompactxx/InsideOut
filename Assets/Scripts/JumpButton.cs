using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public bool isPressed;

    public void OnPointerDown(PointerEventData pointerEventData) 
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData pointerEventData) 
    {
        isPressed = false;
    }
}
