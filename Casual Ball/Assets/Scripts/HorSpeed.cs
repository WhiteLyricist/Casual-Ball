using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class HorSpeed : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Action<float> horSpeed;

    [SerializeField]
    private float _horSpeed;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.delta.x > 0)
        {
            horSpeed(_horSpeed);
        }
        if (eventData.delta.x < 0)
        {
            horSpeed(- _horSpeed);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        horSpeed(0f);
    }
}
