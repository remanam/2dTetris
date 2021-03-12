using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GameController.instance.GetComponent<BlockMover>().rotateButtonPressed = true;
        StartCoroutine(StopClickEvent());
    }

    WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();


    IEnumerator StopClickEvent()
    {
        yield return waitForEndOfFrame;

        Debug.Log("Right button Up");
        GameController.instance.GetComponent<BlockMover>().rotateButtonPressed = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
}
