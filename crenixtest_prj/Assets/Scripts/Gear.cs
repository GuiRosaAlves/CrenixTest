using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Gear : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    private Transform screenSpaceCanvas;
    
    private Vector3 _mousePos;
    
    public Color Color
    {
        get => ImgComponent.color;
        set => ImgComponent.color = value;
    }

    private void Awake()
    {
        screenSpaceCanvas = transform.root;
    }

    
    public Image ImgComponent => gameObject.GetComponent<Image>();
    
    public void ChangeColor(Color newColor)
    {
        Color = newColor;
        ImgComponent.color = Color;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(screenSpaceCanvas.transform);
        transform.localScale = Vector3.one;
        ImgComponent.raycastTarget = false;
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            eventData.pointerCurrentRaycast.gameObject.GetComponent<InvSlot>()?.RemoveGear();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        var aux = Camera.main.ScreenToWorldPoint(eventData.position);
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
        }
        
        ImgComponent.raycastTarget = true;
    }
}
