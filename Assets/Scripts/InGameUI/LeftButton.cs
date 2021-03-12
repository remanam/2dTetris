using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{


    public void OnPointerDown(PointerEventData eventData)
    {
        GameController.instance.GetComponent<BlockMover>().leftButtonPressed = true;
        StartCoroutine(StopClickEvent());
    }

    WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();


    IEnumerator StopClickEvent()
    {
        yield return waitForEndOfFrame;

        Debug.Log("Right button Up");
        GameController.instance.GetComponent<BlockMover>().leftButtonPressed = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
}
