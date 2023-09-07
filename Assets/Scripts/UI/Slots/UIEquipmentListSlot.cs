using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEquipmentListSlot : UISlot
{
    [SerializeField] private GameObject _contentPanel;
    public override Type ContainerType => typeof(UIEquipmentContainer);

    public override void ProcessDrop(UIDragContainer container)
    {
        if (container.OldParent.TryGetComponent<UIEquipmentSlot>(out UIEquipmentSlot slot))
        {
            slot.RemoveEquipmentContainer();
        }
        container.ParentTo(_contentPanel.transform);

        container.ToggleImagePanels(false);
    }
}
