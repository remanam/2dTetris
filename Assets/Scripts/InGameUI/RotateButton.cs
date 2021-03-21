using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]


    public void OnPointerDown(PointerEventData eventData)
    {
        TetrisGrid.rotateButtonPressed = true;
        StartCoroutine(StopClickEvent());
    }

    WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();


    IEnumerator StopClickEvent()
    {
        yield return waitForEndOfFrame;

        Debug.Log("Right button Up");
        TetrisGrid.rotateButtonPressed = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
}
