using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryPanel : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject _contentWeaponPanel;

    public event Action<Equipment> OnUnEquip;

    public void OnDrop(PointerEventData eventData)
    {
        var otherItemTransform = eventData.pointerDrag.transform;

        otherItemTransform.SetParent(_contentWeaponPanel.transform);

        var item = eventData.pointerDrag.GetComponent<UIItem>().Equipment;

        OnUnEquip?.Invoke(item);
    }
}
