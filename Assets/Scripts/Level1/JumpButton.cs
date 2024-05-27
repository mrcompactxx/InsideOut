using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public bool isPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isPressed = false;
        }
    }
    public void OnPointerDown(PointerEventData pointerEventData) 
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData pointerEventData) 
    {
        isPressed = false;
    }
}
