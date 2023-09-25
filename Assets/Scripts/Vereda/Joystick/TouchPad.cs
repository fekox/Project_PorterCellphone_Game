using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchPad : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private RectTransform stick = null;
    [SerializeField] private Image background = null;

    public int playerID;
    public float limit = 2.0f;

    public void OnPointerDown(PointerEventData eventData)
    {
        background.color = Color.red;
        stick.anchoredPosition = ConverToLocal(eventData);
    }

    private Vector2 ConverToLocal(PointerEventData eventData)
    {
        Vector2 newPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle
        (transform as RectTransform,
            eventData.position,
            eventData.enterEventCamera,
            out newPos);
        return newPos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = ConverToLocal(eventData);
        if (pos.magnitude > limit)
            pos = pos.normalized * limit;

        stick.anchoredPosition = pos;

        float x = pos.x / limit;
        float y = pos.y / limit;

        SetHorizontal(x);
        SetVertical(y);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        background.color = Color.gray;
        stick.anchoredPosition = Vector2.zero;
        SetHorizontal(0f);
        SetVertical(0f);
    }

    private void OnDisable()
    {
        SetHorizontal(0f);
        SetVertical(0f);
    }

    private void SetHorizontal(float val) 
    { 
        InputManager.Instance.SetAxis("Horizontal" + playerID, val); 
    }

    private void SetVertical(float val) 
    { 
        InputManager.Instance.SetAxis("Vertical" + playerID, val); 
    }
}
