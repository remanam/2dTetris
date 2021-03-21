using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        TetrisGrid.rightButtonPressed = true;
        StartCoroutine(StopClickEvent());
    }

    WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();

    
    IEnumerator StopClickEvent()
    {
        yield return waitForEndOfFrame;

        Debug.Log("Right button Up");
        TetrisGrid.rightButtonPressed = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
}
