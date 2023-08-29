using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryPanel : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject _contentItemPanel;
    [SerializeField] private DepotType _depotType;

    public Inventory Inventory { get; set; }
    public event Action<Equipment> OnItemDrop;

    void Start()
    {
        Refresh();
    }

    public void OnDrop(PointerEventData eventData)
    {
        var otherItemTransform = eventData.pointerDrag.transform;
        otherItemTransform.SetParent(_contentItemPanel.transform);

        var item = eventData.pointerDrag.GetComponent<UIItem>().Equipment;
        OnItemDrop?.Invoke(item);
    }

    public void Refresh()
    {
        if (_contentItemPanel == null)
        {
            throw new NullReferenceException("Content item panel is null");
        }

        foreach (Transform item in _contentItemPanel.GetComponentInChildren<Transform>())
        {
            Destroy(item.gameObject);
        }

        List<Equipment> equipments = Inventory.Equipments;
        List<ResourceItem> resources = Inventory.ResourceItems;

        foreach (var item in equipments)
        {
            ItemFactory.CreateItem(item, _contentItemPanel.transform);
        }
    }
}
