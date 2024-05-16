using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEquipmentListSlot : UISlot
{
    [SerializeField] private GameObject _contentPanel;
    public override Type ContainerType => typeof(UIDragItemContainer);
    public override void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent<UIDragContainer>(out UIDragContainer container))
        {
            //if (!IsAcceptable(container))
            //{
            //    return;
            //}

            //container.ParentTo(transform);
            //container.transform.localScale = ContentScale;

            ProcessDrop(container);
        }
    }
    public override void ProcessDrop(UIDragContainer container)
    {
        //if (container.OldParent.TryGetComponent<UIEquipmentSlot>(out UIEquipmentSlot slot))
        //{
        //    slot.RemoveEquipmentContainer();
        //}
        //container.ParentTo(_contentPanel.transform);

        //container.ToggleImagePanels(false);
        if(_contentPanel.TryGetComponent<UIStorageItemListController>(out UIStorageItemListController StoragePositionListController))
        {
            var item = (container as UIDragItemContainer).Item;
            StoragePositionListController.DropItemContainer(item);
            Destroy(container.gameObject);
        }
    }
}
