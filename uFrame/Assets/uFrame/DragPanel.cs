using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class DragPanel : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform canvasRectTransform;
    private RectTransform panelRectTransform;
    private Vector2 pointerOffset;

    public void Init(Transform canvas, Transform panel) 
    {
        canvasRectTransform = canvas.transform as RectTransform;
        panelRectTransform = panel as RectTransform;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        panelRectTransform.SetAsLastSibling();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(panelRectTransform, eventData.position, 
                                                                eventData.pressEventCamera, out pointerOffset);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pointerPos = ClampToWindow(eventData);
        Vector2 localPointerPos;
        var success = RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, pointerPos, 
                                                                        eventData.pressEventCamera, out localPointerPos);
        if (success)
        {
            panelRectTransform.localPosition = localPointerPos - pointerOffset;
        }
    }

    private Vector2 ClampToWindow(PointerEventData eventData)
    {
        var rawPointerPos = eventData.position;
        var canvasCorners = new Vector3[4];
        canvasRectTransform.GetWorldCorners(canvasCorners);

        var clampedX = Mathf.Clamp(rawPointerPos.x, canvasCorners[0].x, canvasCorners[2].x);
        var clampedY = Mathf.Clamp(rawPointerPos.y, canvasCorners[0].y, canvasCorners[2].y);

        var newPointerPos = new Vector2(clampedX, clampedY);
        return newPointerPos;
    }
}
