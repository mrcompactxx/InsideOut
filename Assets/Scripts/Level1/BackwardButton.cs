using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackwardButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public bool isPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            isPressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.A))
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
