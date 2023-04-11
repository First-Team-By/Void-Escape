using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Equipment 
{
    [SerializeField] private SlotType _slotType;
    public SlotType SlotType
    {
        get { return _slotType; }
        set { _slotType = value; }
    }
    public Sprite Icon { get; set; }
    public abstract string IconName { get; }

    public Equipment()
    {
        Icon = Resources.Load<Sprite>("Sprites/" + IconName);
    }
}
