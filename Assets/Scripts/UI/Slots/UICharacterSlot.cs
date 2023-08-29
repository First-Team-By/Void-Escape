using System;
using UnityEngine;

public class UICharacterSlot : UISlot
{
    [SerializeField] private Transform _contentPanel;
    public override Type ContainerType => typeof(UICharacterContainer);

    public override void ProcessDrop(UIDragContainer container)
    {
        container.transform.SetParent(_contentPanel);

        container.ToggleImagePanels(false);

        if (container.OldParent.TryGetComponent<UIMedCapsuleSlot>(out UIMedCapsuleSlot slot))
        {
            slot.ButtonPanel.SetActive(false);
            slot.Character = null;
        }

        container.transform.localScale = Vector2.one;
    }
}
