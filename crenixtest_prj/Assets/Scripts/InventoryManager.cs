using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Gear[] _inventory= new Gear[0];
    [SerializeField] private Transform[] _invSlots = new Transform[0];
    
    
    
    public Gear[] Inv => _inventory;

    public void ResetInv()
    {
        
    }
}
