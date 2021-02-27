using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlacementSlot : InvSlot
{
    public UnityEvent onGearDropped;
    public UnityEvent onGearRemoved;
    
    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
        onGearDropped.Invoke();
    }

    public override void RemoveGear()
    {
        base.RemoveGear();
        onGearRemoved.Invoke();
    }
}
