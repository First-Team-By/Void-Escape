using System;
using UnityEngine;

public class UIEquipmentSlot : UISlot
{
    [SerializeField] private SlotType _slotType;

    public UIDragItemContainer EquipmentContainer
    {
        get => Container as UIDragItemContainer;
        set => Container = value;
    } 
    public override Type ContainerType => typeof(UIDragItemContainer);

    public event Action<Equipment> OnEquipped;
    public event Action<Equipment> OnUnEquip;

    public override void ProcessDrop(UIDragContainer container)
    {
        container.ToggleImagePanels(true);

        var newContainer = (UIDragItemContainer)container;

        if (EquipmentContainer != null)
        {
            if (container.OldParent.TryGetComponent(out UIStorgePositionListController parentStorePositionListController))
            {
                parentStorePositionListController.DropItemContainer(EquipmentContainer.Item);
                Destroy(EquipmentContainer.gameObject);
            }
            else
            {
                EquipmentContainer.ParentTo(container.OldParent);
            }
            OnUnEquip?.Invoke(EquipmentContainer.Item as Equipment);
        }

        EquipmentContainer = newContainer;
        OnEquipped?.Invoke(newContainer.Item as Equipment);
    }

    public void RemoveEquipmentContainer()
    {
        OnUnEquip?.Invoke(EquipmentContainer.Item as Equipment);
        EquipmentContainer = null;
    }

    protected override bool IsAcceptable(UIDragContainer container)
    {
        var equipmentContainer = container as UIDragItemContainer;
        bool result = equipmentContainer != null && equipmentContainer.Item.SlotType == _slotType;
        return result;
    }
}
