using System;
using System.ComponentModel;
using UnityEngine;

public class UIEquipmentSlot : UISlot
{
    [SerializeField] private SlotType _slotType;

    public UIEquipmentContainer EquipmentContainer
    {
        get => Container as UIEquipmentContainer;
        set => Container = value;
    } 
    public override Type ContainerType => typeof(UIEquipmentContainer);

    public event Action<Equipment> OnEquipped;
    public event Action<Equipment> OnUnEquip;

    public override void ProcessDrop(UIDragContainer container)
    {
        container.ToggleImagePanels(true);

        var newContainer = (UIEquipmentContainer)container;

        if (EquipmentContainer != null)
        {
            EquipmentContainer.ParentTo(container.OldParent);
            OnUnEquip?.Invoke(EquipmentContainer.Equipment);
        }

        EquipmentContainer = newContainer;
        OnEquipped?.Invoke(newContainer.Equipment);
    }

    public void RemoveEquipmentContainer()
    {
        OnUnEquip?.Invoke(EquipmentContainer.Equipment);
        EquipmentContainer = null;
    }

    protected override bool IsAcceptable(UIDragContainer container)
    {
        var equipmentContainer = container as UIEquipmentContainer;
        bool result = equipmentContainer != null && equipmentContainer.Equipment.SlotType == _slotType;
        return result;
    }
}
