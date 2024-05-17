using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIStoragePositionListSlot : UISlot
{
    [SerializeField] private GameObject _contentPanel;
    public override Type ContainerType => typeof(UIDragItemContainer);
    public override void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent<UIDragContainer>(out UIDragContainer container))
        {
            ProcessDrop(container);
        }
    }
    public override void ProcessDrop(UIDragContainer container)
    {
        if(_contentPanel.TryGetComponent<UIStorageItemListController>(out UIStorageItemListController StoragePositionListController))
        {
            var item = (container as UIDragItemContainer).Item;
            StoragePositionListController.DropItemContainer(item);
            Destroy(container.gameObject);
        }
    }
}
