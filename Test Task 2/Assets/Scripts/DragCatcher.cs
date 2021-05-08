using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragCatcher : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    public Controller playerController;
    public float sensitivity = 1000f;
    public Camera camera;
    public void OnDrag(PointerEventData eventData)
    {
        //float x = camera.ScreenToViewportPoint(eventData.delta).x;
        var delta = (eventData.delta.x / Screen.width) * sensitivity;
        print(delta);
        playerController.SetTargetPosition(delta);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
}
