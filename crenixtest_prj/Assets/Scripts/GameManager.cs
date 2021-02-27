using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private int _gearsPlaced = 0;
    public UnityEvent onAllGearsPlaced;
    public UnityEvent onReset;

    public void GearPlaced() => _gearsPlaced++;

    public void GearRemoved() { if(_gearsPlaced > 0) _gearsPlaced--; }

    public Gear[] gears;
    public InvSlot[] invSlots;

    public void Update()
    {
        if (_gearsPlaced == 5)
        {
            onAllGearsPlaced.Invoke();
        }
    }

    public void Reset()
    {
        _gearsPlaced = 0;
        for (int i = 0; i < invSlots.Length; i++)
        {
            invSlots[i].SetCurrGear(gears[i]);
        }
        
        onReset.Invoke();
    }
}
