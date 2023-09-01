using System;
using UnityEngine;

public class UIEquipmentSlot : UISlot
{
    [SerializeField] private SlotType _slotType; 
    private UIDragContainer _equipmentContainer;
    public override Type ContainerType => typeof(UIEquipmentContainer);

    public override void ProcessDrop(UIDragContainer container)
    {
        container.ToggleImagePanels(true);

        if (_equipmentContainer != null)
        {
            _equipmentContainer.ParentTo(container.OldParent);
        }

        _equipmentContainer = container;
    }

    public void RemoveEquipmentContainer()
    {
        _equipmentContainer = null;
    }

    protected override bool IsAcceptable(UIDragContainer container)
    {
        var equipmentContainer = container as UIEquipmentContainer;
        bool result = equipmentContainer != null && equipmentContainer.Equipment.SlotType == _slotType;
        return result;
    }
}
