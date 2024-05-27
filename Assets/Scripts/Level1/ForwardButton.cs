using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ForwardButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public bool isPressed;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            isPressed = true;
        }
        else if(Input.GetKeyUp(KeyCode.D)) 
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
