using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum SlotType
{
    Weapon,
    Device,
    Armor,
    Inventory
}

public class EquipmentSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private SlotType _type;

    [SerializeField] private GameObject _uiSlot;

    private UIItem _mountedItem;

    private UIItem _newItem;

    private Image _equipSlotImage;

    public SlotType Type => _type;

    public event Action<Equipment> OnEquipped;

    public void OnDrop(PointerEventData eventData)
    {
        if (_uiSlot.transform.childCount == 0)
        {
            _mountedItem = eventData.pointerDrag.GetComponent<UIItem>();

            if (Type != _mountedItem.SlotType)
            {
                _mountedItem.transform.SetParent(_mountedItem.OldParent.transform);

                return;
            }

            var otherItemTransform = eventData.pointerDrag.transform;

            otherItemTransform.SetParent(transform);

            otherItemTransform.localPosition = Vector3.zero;
        }
        else
        {
            _newItem = eventData.pointerDrag.GetComponent<UIItem>();

            if (Type != _newItem.SlotType)
            {
                _newItem.transform.SetParent(_newItem.OldParent.transform);

                return;
            }

            var otherItemTransform = eventData.pointerDrag.transform;

            otherItemTransform.SetParent(transform);

            otherItemTransform.localPosition = Vector3.zero;

            _mountedItem.transform.SetParent(_mountedItem.OldParent.transform);

            _mountedItem = _newItem;
        }

        OnEquipped?.Invoke(_mountedItem.Equipment);

        _equipSlotImage = gameObject.GetComponent<Image>();

        _equipSlotImage.sprite = null;
    }
}
