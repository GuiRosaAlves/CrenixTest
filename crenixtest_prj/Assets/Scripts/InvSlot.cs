using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InvSlot : MonoBehaviour , IDropHandler
{
    [SerializeField] private Vector3 gearScale;
    public Gear CurrGear { get; private set; }
    
    public virtual void OnDrop(PointerEventData eventData)
    {
        if (CurrGear == null)
        {
            var droppedGear = eventData.pointerDrag.GetComponent<Gear>();
            var gearTransform = droppedGear.transform;
        
            SetCurrGear(droppedGear);
        }
    }

    public void SetCurrGear(Gear newGear)
    {
        CurrGear = newGear;
        newGear.transform.SetParent(transform);
        newGear.transform.localPosition = Vector3.zero;
        newGear.transform.localScale = gearScale;
        newGear.ImgComponent.raycastTarget = true;
    }

    public virtual void RemoveGear()
    {
        CurrGear = null;
    }
}
