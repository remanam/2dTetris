using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AccelerationButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GameController.accelerationButtonPressed = true;
    }





    public void OnPointerUp(PointerEventData eventData)
    {
        GameController.rotateButtonPressed = false;
    }
}
