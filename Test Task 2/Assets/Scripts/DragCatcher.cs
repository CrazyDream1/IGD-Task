using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragCatcher : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    public Controller playerController;
    public void OnDrag(PointerEventData eventData)
    {
        playerController.SetTargetPosition(eventData.delta.x);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
}
