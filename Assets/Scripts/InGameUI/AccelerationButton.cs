using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AccelerationButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GameController.instance.GetComponent<BlockMover>().accelerationButtonPressed = true;
    }





    public void OnPointerUp(PointerEventData eventData)
    {
        GameController.instance.GetComponent<BlockMover>().rotateButtonPressed = false;
    }
}
