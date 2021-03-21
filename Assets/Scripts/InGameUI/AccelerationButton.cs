using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AccelerationButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        TetrisGrid.accelerationButtonPressed = true;
    }





    public void OnPointerUp(PointerEventData eventData)
    {
        TetrisGrid.rotateButtonPressed = false;
    }
}
