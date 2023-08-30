using System;
using UnityEngine;

public class UIEquipmentSlot : UISlot
{
    [SerializeField] private SlotType _slotType; 
    public override Type ContainerType => typeof(UIEquipmentContainer);

    public override void ProcessDrop(UIDragContainer container)
    {
        container.ToggleImagePanels(true);

        //container.transform.localScale = Vector2.one;
    }

    protected override bool IsAcceptable(UIDragContainer container)
    {
        var equipmentContainer = container as UIEquipmentContainer;
        bool result = equipmentContainer != null && equipmentContainer.Equipment.SlotType == _slotType;
        return result;
    }
}
