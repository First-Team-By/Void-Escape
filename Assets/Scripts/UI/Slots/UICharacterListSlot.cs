using System;
using UnityEngine;

public class UICharacterListSlot : UISlot
{
    [SerializeField] private Transform _contentPanel;
    public override Type ContainerType => typeof(UIDragCharacterContainer);

    public override void ProcessDrop(UIDragContainer container)
    {
        container.transform.SetParent(_contentPanel);

        container.ToggleImagePanels(false);

        if (container.OldParent.TryGetComponent<UIMedCapsuleSlot>(out UIMedCapsuleSlot slot))
        {
            slot.ButtonPanel.SetActive(false);
            slot.Character = null;
        }
    }
}
