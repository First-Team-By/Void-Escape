using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;


public class EquipmentSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private SlotType _type;

    [SerializeField] private GameObject _uiSlot;

    [SerializeField] private RectTransform _inventoryContent;

    [SerializeField] private Sprite _defaulImage;

    private UIItem _mountedItem;

    private UIItem _newItem;

    private Image _equipSlotImage;

    

    public Image EquipSlotImage
    {
        get { return _equipSlotImage; }

        set { _equipSlotImage = value; }
    }
    public SlotType Type => _type;

    public event Action<Equipment> OnEquipped;

    public event Action<Equipment> OnUnEquip;

    private void Start()
    {
        _equipSlotImage = gameObject.GetComponent<Image>();

        if (_uiSlot.transform.childCount > 0)
        {
            _equipSlotImage.sprite = null;
        }
    }

    public void SetDefaultImage()
    {
        EquipSlotImage.sprite = _defaulImage;
    }

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

            _mountedItem = _uiSlot.GetComponentInChildren<UIItem>();

            if (Type != _newItem.SlotType)
            {
                _newItem.transform.SetParent(_newItem.OldParent.transform);

                return;
            }

            var otherItemTransform = eventData.pointerDrag.transform;

            otherItemTransform.SetParent(transform);

            otherItemTransform.localPosition = Vector3.zero;

            if(_inventoryContent != null)
            {
                _mountedItem.transform.SetParent(_inventoryContent);

                OnUnEquip?.Invoke(_mountedItem.Equipment);
            }

            _mountedItem = _newItem;
        }

        OnEquipped?.Invoke(_mountedItem.Equipment);

        _equipSlotImage.sprite = null;
    }
}
